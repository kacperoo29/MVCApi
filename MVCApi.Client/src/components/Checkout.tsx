import React, { useEffect, useState } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CustomerApi, CustomerDto, OrderApi, ShoppingCartDto } from '../api'
import { getOrCreateCart } from '../util/CartUtil'
import LocaleCurrency from 'locale-currency'
import { useIntl } from 'react-intl'
import Cookies from 'universal-cookie'
import { useHistory } from 'react-router'

export function Checkout() {
    const [customers, setCustomers] = useState<CustomerDto[]>([])
    const [customerIdx, setCustomerIdx] = useState<number | null>(null)
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const intl = useIntl()
    const history = useHistory()

    useEffect(() => {
        const api = new CustomerApi()
        api.apiCustomerGetAllCustomersGet()
            .then(r => setCustomers(r))
            .catch(e => console.log(e))

        getOrCreateCart(LocaleCurrency.getCurrency(intl.locale))
            .then(r => setCart(r))
    }, [intl.locale])

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {        
        e.preventDefault()
        e.stopPropagation()

        let valid = true
        if (customerIdx != null && !customers[customerIdx]) {
            valid = false
        }

        if (!cart) {
            valid = false
        }

        if (valid) {
            console.log("inside")
            const api = new OrderApi()
            api.apiOrderCreateOrderPost({ createOrder: { cartId: cart.id, customerId: customers[customerIdx!].id } })
                .then(r => {
                    const cookies = new Cookies()
                    cookies.remove("cartId")
                    history.push('/orders')
                })
        }
    }

    return (
        <>
            <Form noValidate onSubmit={(e) => handleSubmit(e)}>
                <Row className="mb-2">
                    <Form.Group as={Col}>
                        <Form.Select onChange={e => setCustomerIdx(parseInt(e.target.value))}>
                            {customers.map((customer, key) =>
                                <option key={customer.id} value={key}>{customer?.firstName! + ' '+ customer?.lastName!}</option>
                            )}
                        </Form.Select>
                    </Form.Group>
                    <Button type='submit'>Submit</Button>
                </Row>
            </Form>
        </>
    )
}
