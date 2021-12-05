import React, { useEffect, useState } from 'react'
import { CategoryApi, CategoryDto } from '../api'
import { CategoryTree } from './'

export function Categories() {
    const [categories, setCategories] = useState<CategoryDto[]>([])

    useEffect(() => {
        const api = new CategoryApi()
        api.apiCategoryGetRootCategoriesGet()
            .then(response => setCategories(response))
    }, [])

    return (
        <div className="row">
            {categories.map(category =>                
                <div key={category.id} className='col-md-4'>
                    <CategoryTree category={category} />
                </div>
            )}
        </div>
    )
}