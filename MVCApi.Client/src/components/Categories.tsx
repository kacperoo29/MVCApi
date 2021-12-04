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
                <div key={category.id} className='col-md-4'>
                    <CategoryTree category={category} />
                </div>
            )}
        </>
    )
}