import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CategoryApi, CategoryDto } from '../api'

interface CategoryErrors {
    name?: string | null
    parent?: string | null
}

type CategoryFormProps = {
    added: boolean
    setAdded: React.Dispatch<React.SetStateAction<boolean>>
}

export function CategoryForm({ added, setAdded }: CategoryFormProps) {
    const [categoryName, setCategoryName] = useState<string>("")
    const [parent, setParent] = useState<CategoryDto | null>(null)
    const [categories, setCategories] = useState<CategoryDto[]>([])
    const [isChild, setIsChild] = useState<boolean>(false)
    const [errors, setErrors] = useState<CategoryErrors>({})
    //const [added, setAdded] = useState<boolean>(false)

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {

        let valid = true;
        let newErrors: CategoryErrors = {}
        e.preventDefault()

        if (isChild) {
            if (!parent) {
                valid = false;
                newErrors.parent = "You must select parent when creating subcategory"
            }
        }

        if (!categoryName) {
            valid = false;
            newErrors.name = "Category name cannot be empty"
        }

        setErrors(newErrors)

        if (valid) {
            const api = new CategoryApi()
            if (!isChild) {
                api.apiCategoryCreateCategoryPost({ createCategory: { name: categoryName } })
                    .then(r => setAdded(!added))
            } else {
                api.apiCategoryCreateSubcategoryPost({ createSubcategory: { name: categoryName, parentId: parent?.id } })
                    .then(r => setAdded(!added))
            }
        }
    }

    useEffect(() => {
        const api = new CategoryApi()
        api.apiCategoryGetAllCategoriesGet()
            .then(response => {
                setCategories(response)
            })
    }, [added])

    return (
        <Form noValidate onSubmit={e => handleSubmit(e)}>
            <Row className="mb-2 input-group">
                <Form.Group as={Col}>
                    <Form.Label>Category name</Form.Label>
                    <Form.Control isInvalid={!!errors['name']} required type="text" placeholder='Category name' name='name' onChange={e => setCategoryName(e.target.value)} />
                    <Form.Control.Feedback type='invalid'>{errors['name']}</Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col}>
                    <Form.Label>Is subcategory?</Form.Label>
                    <Form.Check type='checkbox' name='isChild' onChange={(e) => setIsChild(e.target.checked)} />
                </Form.Group>
                <Form.Group as={Col}>
                    <Form.Label>Parent category</Form.Label>
                    <Form.Select isInvalid={!!errors['parent']} name='parent' disabled={!isChild} onChange={e => setParent(e.target.value ? categories[parseInt(e.target.value)] : null)} >
                        <option value=''></option>
                        {categories.map((category, idx) =>
                            <option key={category.id} value={idx}>{category.name}</option>
                        )}
                    </Form.Select>
                    <Form.Control.Feedback type='invalid'>{errors['parent']}</Form.Control.Feedback>
                </Form.Group>
                <div className="col align-self-end">
                    <Button type="submit">Submit</Button>
                </div>
            </Row>
        </Form>
    )

} 