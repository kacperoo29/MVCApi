import React, { useEffect, useState } from 'react'
import { CategoryApi, CategoryDto } from '../api'
import { CategoryForm, CategoryTree } from './'

export function Categories() {
    const [categories, setCategories] = useState<CategoryDto[]>([])
    const [added, setAdded] = useState<boolean>(false)

    useEffect(() => {
        const api = new CategoryApi()
        api.apiCategoryGetRootCategoriesGet()
            .then(response => setCategories(response))
    }, [added])

    return (
        <>
            <div className="row mb-4">
                {categories.map(category =>
                    <div key={category.id} className='col-md-4'>
                        <CategoryTree category={category} />
                    </div>
                )}
            </div>
            <CategoryForm added={added} setAdded={setAdded} />
        </>
    )
}