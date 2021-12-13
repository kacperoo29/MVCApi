import React, { useEffect, useState } from 'react'
import { OrderDto, OrderApi } from '../api/index'
import { Table } from 'react-bootstrap'
import { useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'

export function Orders() {
    const [orders, setOrders] = useState<OrderDto[] | []>([])
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
                    <th>Order status</th>
                </tr>
            </thead>
            <tbody>
                {orders.map(order => (
                    <tr key={order.id}>
                        <td>{order.customer?.firstName}</td>
                        <td>{order.orderState}</td>
                    </tr>
                ))}
            </tbody>
        </Table>);
}