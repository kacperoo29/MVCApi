import React from "react";
import { CategoryDto } from "../api";

type CategoryTreeProps = {
    category: CategoryDto
}

export default function CategoryTree({ category }: CategoryTreeProps) {
    return (
        <>
            {category.children &&
                <ul className="list-group">
                    {category.children.map(child =>
                        <li className="list-group-item list-group-item-action" key={child.id}>{child.name}
                            {child.children && <CategoryTree category={child} />}
                        </li>
                    )}
                </ul>
            }
        </>

    )
}