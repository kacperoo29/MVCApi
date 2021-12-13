import React, { useEffect, useState } from 'react'
import { OrderDto, OrderApi } from '../api/index'
import { Collapse, Table } from 'react-bootstrap'
import { useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'

export function Orders() {
    const [orders, setOrders] = useState<OrderDto[] | []>([])
    const [toggleState, setToggleState] = useState<any>({})
    const intl = useIntl()

    useEffect((api = new OrderApi()) => {
        api.apiOrderGetAllOrdersGet({ currencyCode: LocaleCurrency.getCurrency(intl.locale) })
            .then(response => setOrders(response))
    }, [intl.locale]);

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Customer name</th>
                    <th>Order details</th>
                </tr>
            </thead>
            <tbody>
                {orders.map((order, key) => (
                    <tr key={order.id}>
                        <td>{order.customer?.firstName}</td>
                        <td>
                            <button className='btn btn-primary mb-2' type='button' onClick={() => setToggleState(() => ({ ...toggleState, [key]: !toggleState[key] }))}>
                                Show
                            </button>
                            <Collapse in={toggleState[key]}>
                                <div className='card card-body'>
                                    {order.shoppingCart?.products?.map((product, key) =>
                                        <p key={key}>{`Product name: ${product.product?.name} Count: ${product.count}`}</p>
                                    )}
                                </div>
                            </Collapse>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>);
}