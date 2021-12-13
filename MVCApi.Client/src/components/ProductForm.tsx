import React, { useEffect, useState } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CreateProduct, ProductApi, CategoryDto, CategoryApi } from '../api'

interface CreateProductErrors {
    name?: string | null,
    description?: string | null,
    image?: string | null,
    price?: string | null,
    category?: string | null
}

export function ProductForm() {
    const [product, setProduct] = useState<CreateProduct>({})
    const [errors, setErrors] = useState<CreateProductErrors>({})
    const [categories, setCategories] = useState<CategoryDto[]>([])
    const [category, setCategory] = useState<CategoryDto | null>(null)
    const [response, setResponse] = useState<string>('')

    const validation = (): boolean => {

        let valid = true;
        let newErrors: CreateProductErrors = {};

        if (!product.name) {
            newErrors.name = "Product name must be set!";
            valid = false;
        } else {
            // Additional checks
        }

        if (!product.description) {
            newErrors.description= "Description must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!product.image) {
            newErrors.image= "Image must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!product.price) {
            newErrors.price = "Product image must be set!";
            valid = false;
        } else {
            if (product.price.valueOf() < 0) {
                newErrors.price = "Price must be greater than 0";
                valid = false;
            }
        }

        if (!category) {
            valid = false;
            newErrors.category = "You must choose a category"
        }

        setErrors(newErrors)

        return valid;
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        event.stopPropagation()

        if (validation()) {
            const api = new ProductApi()
            const categoryApi = new CategoryApi()
            
                api.apiProductCreateProductPost({ createProduct: product }).then(
                    response => {
                        categoryApi.apiCategoryAddProductToCategoryPut({
                            addProductToCategory: { categoryId: category?.id, productId: response.replaceAll('"', '') }
                        }).then(() => setResponse("Succesfully added a product"))
                        .catch(() => setResponse("Couldn't add product to category"))
                    }
                ).catch(() => setResponse("Something went wrong, try again"))            
        }
    }

    const handleChangeProduct = (event: React.ChangeEvent<HTMLInputElement>) => {
        setProduct({ ...product, [event.target.name]: event.target.value })
        console.log(product)
    }

    useEffect(() => {
        const api = new CategoryApi()
        api.apiCategoryGetAllCategoriesGet()
            .then(response => setCategories(response))
    }, [])

    return (

        <Form noValidate onSubmit={(e) => handleSubmit(e)}>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product name</Form.Label>
                    <Form.Control isInvalid={!!errors['name']} required type="text" placeholder='Name of a product' name='name' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['name']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product description</Form.Label>
                    <Form.Control isInvalid={!!errors['description']} required type="text" placeholder='Product description' name='description' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['description']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product image</Form.Label>
                    <Form.Control isInvalid={!!errors['image']} required type="text" placeholder='Product image file' name='image' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['image']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product price</Form.Label>
                    <Form.Control isInvalid={!!errors['price']} required type="number" step="0.01" placeholder='0' name='price' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['price']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Category</Form.Label>
                    <Form.Select isInvalid={!!errors['category']} name='parent' onChange={e => setCategory(e.target.value ? categories[parseInt(e.target.value)] : null)} >
                        <option value=''></option>
                        {categories.map((category, idx) =>
                            <option key={category.id} value={idx}>{category.name}</option>
                        )}
                    </Form.Select>
                    <Form.Control.Feedback type='invalid'>{errors['category']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-3">
                <Button type="submit">Submit</Button>
            </Row>
            <Row className="mb-3">
                <p className="text-info">{response}</p>
            </Row>
        </Form>
    );

}
