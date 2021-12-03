import React, { useEffect, useState } from 'react'
import { ShoppingCartDto } from '../api'
import { Table } from 'react-bootstrap'
import { getOrCreateCart } from '../util/CartUtil'
import { FormattedNumber, useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'

export default function Cart() {
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const intl = useIntl()

    useEffect(() => {
        getOrCreateCart(LocaleCurrency.getCurrency(intl.locale))
            .then(cart => setCart(cart))
            .catch(e => console.log(e))
    }, [intl.locale])

    return (<Table striped bordered hover>
        <thead>
            <tr>
                <th>Product</th>
                <th>Count</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>
            {cart.products?.map(product => (
                <tr key={product.product?.id}>
                    <td>{product.product?.name}</td>
                    <td>{product.count}</td>
                    <td>
                        <FormattedNumber
                            value={product.product?.price?.value!}
                            style={"currency"}
                            currency={product.product?.price?.currency?.code!}
                        />
                    </td>
                </tr>
            ))}
        </tbody>
    </Table>
    )

}