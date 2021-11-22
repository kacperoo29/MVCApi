import React, { useEffect, useState } from 'react'
import Cookies from 'universal-cookie'
import { CartApi, ShoppingCartDto } from '../api'
import { Table } from 'react-bootstrap'

export default function Cart() {
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const cookies = new Cookies()
    //let cartId: string | null | undefined = cookies.get("cartId") 
    const [cartId, setCartId] = useState<string | null | undefined>(cookies.get("cartId"))

    useEffect(() => {
        const api = new CartApi()
        if (!cartId || cartId === 'undefined') {
            api.apiCartCreateCartPost({}).then(response => {
                setCartId(response)
                // eslint-disable-next-line
                cookies.set("cartId", cartId)
            })
        }

        if (cartId)
            api.apiCartGetCartByIdCartIdGet({ cartId }).then(response => response && setCart(response))

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