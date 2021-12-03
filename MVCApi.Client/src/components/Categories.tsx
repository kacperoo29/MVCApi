import React, { useEffect, useState } from 'react'
import { CategoryApi, CategoryDto } from '../api'
import CategoryTree from './CategoryTree'

export default function Categories() {
    const [categories, setCategories] = useState<CategoryDto[]>([])

    useEffect(() => {
        const api = new CategoryApi()
        api.apiCategoryGetRootCategoriesGet()
            .then(response => setCategories(response))
    }, [])

    return (
        <>
            {categories.map(category =>                
                <div className='col-md-4'>
                    <h4>{category.name}</h4>
                    <CategoryTree category={category} />
                </div>
            )}
        </>
    )
}