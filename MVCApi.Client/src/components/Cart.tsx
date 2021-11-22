import React, { useEffect, useState } from 'react'
import { CartApi, ShoppingCartDto } from '../api'
import { Table } from 'react-bootstrap'
import { getOrCreateCart } from '../util/CartUtil'

export default function Cart() {
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const [cartId, setCartId] = useState<string | null | undefined>(null)

    useEffect(() => {
        getOrCreateCart().then(id => setCartId(id))
        
        if (cartId) {
            const api = new CartApi()
            api.apiCartGetCartByIdCartIdGet({ cartId }).then(response => setCart(response))
            console.log(cart)
        }
    }, [cartId])

    return (<Table striped bordered hover>
        <thead>
            <tr>
                <th>Product</th>
                <th>Count</th>
            </tr>
        </thead>
        <tbody>
            {cart.products?.map(product => (
                <tr key={product.product?.id}>
                    <td>{product.product?.name}</td>
                    <td>{product.count}</td>
                </tr>
            ))}
        </tbody>
    </Table>
    )

}