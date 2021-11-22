import React, { useEffect, useState } from 'react'
import { OrderDto, OrderApi } from '../api/index'
import { Table } from 'react-bootstrap'

export default function Orders(){
    const [orders, setOrders] = useState<OrderDto[] | []>([])    

    useEffect((api = new OrderApi())=>{
        api.apiOrderGetAllOrdersGet().then(response => setOrders(response))
    }, []);

    return(
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Order id</th>
                    <th>Customer name</th>
                    <th>Order status</th>
                </tr>
            </thead>
            <tbody>
                {orders.map(order => (
                    <tr key={order.id}>
                    <td>{order.id}</td>
                    <td>{order.customer?.firstName}</td>
                    <td>{order.orderState}</td>
                    </tr>
                ))}
            </tbody>
        </Table>);
}