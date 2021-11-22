import React, { useEffect, useState } from 'react'
import Cookies from 'universal-cookie'
import { CartApi, ShoppingCartDto } from '../api'
import { Table } from 'react-bootstrap'
import moment from 'moment'
import { getOrCreateCart } from '../util/CartUtil'

export default function Cart() {
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const [cartId, setCartId] = useState<string | null | undefined>(null)

    useEffect(() => {
        getOrCreateCart().then(id => setCartId(id))
        
        if (cartId) {
            const api = new CartApi()
            api.apiCartGetCartByIdCartIdGet({ cartId }).then(response => response && setCart(response))
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
            {cart.products && cart.products.map(product => (
                <tr key={product.product?.id}>
                    <td>{product.product?.name}</td>
                    <td>{product.count}</td>
                </tr>
            ))}
        </tbody>
    </Table>
    )

}