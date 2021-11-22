import React, { useEffect, useState } from 'react'
import { ProductDto, ProductApi } from '../api/index'
import { Table } from 'react-bootstrap'

export default function Products() {
    const [products, setProducts] = useState<ProductDto[] | []>([])

    useEffect((api = new ProductApi()) => {
        api.apiProductGetAllProductsGet().then(response => setProducts(response))
    }, []);

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Product id</th>
                    <th>Product name</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                {products.map(product => (
                    <tr key={product.id}>
                        <td>{product.id}</td>
                        <td>{product.name}</td>
                        <td>{product.description}</td>
                    </tr>
                ))}
            </tbody>
        </Table>);
}