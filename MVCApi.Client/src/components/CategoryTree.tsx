import React from "react";
import { Link } from "react-router-dom";
import { CategoryDto } from "../api";

type CategoryTreeProps = {
    category: CategoryDto
}

// TODO: Make down and up limit from root
export default function CategoryTree({ category }: CategoryTreeProps) {
    return (
        <>
            <ul className="list-group">
                <li className="list-group-item list-group-item-action" key={category.id} >
                    <Link
                        className='text-decoration-none font-weight-bold text-reset'
                        to={{ pathname: '/products', state: { categoryId: category.id } }}                        
                        style={{ width: '100%', display: "block", height: '100%' }}
                        
                    >
                        <span>{category.name}</span>
                    </Link>
                    {category.children && category.children.map(child =>
                        <CategoryTree key={child.id} category={child} />
                    )}
                </li>
            </ul>
        </>
    )
}