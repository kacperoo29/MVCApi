import React, { useState } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CreateCustomer, AddressDto } from '../api/index'

export default function CustomerForm(props: any) {
    const [customer, setCustomer] = useState<CreateCustomer>({})

    const [valid, setValid] = useState<boolean>(false)

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log(customer)
    }

    const handleChangeCustomer = (event: React.ChangeEvent<HTMLInputElement>) => {
        setCustomer({ ...customer, [event.target.name]: event.target.value })
    }

    return <Form noValidate validated={valid} onSubmit={handleSubmit}>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>First name</Form.Label>
                <Form.Control required type="text" placeholder='First name' name='firstName' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Last name</Form.Label>
                <Form.Control required type="text" placeholder='Last name' name='lastName' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Date of birth</Form.Label>
                <Form.Control required type="date" name='dateOfBirth' onChange={handleChangeCustomer} />
            </Form.Group>
        </Row>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Country</Form.Label>
                <Form.Control required type="text" placeholder='Country' name='country' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>City</Form.Label>
                <Form.Control required type="text" placeholder='City' name='city' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Street</Form.Label>
                <Form.Control required type="text" placeholder='Street' name='street' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group xs={1} as={Col}>
                <Form.Label>Street number</Form.Label>
                <Form.Control required type="text" placeholder='Street number' name='streetNumber' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group xs={2} as={Col}>
                <Form.Label>Post code</Form.Label>
                <Form.Control required type="text" placeholder='Post code' name='postCode' onChange={handleChangeCustomer} />
            </Form.Group>
        </Row>
        <Row className="mb-2">
        <Form.Group as={Col}>
            <Form.Label>Email</Form.Label>
                <Form.Control required type="email" placeholder='Email' name='email' onChange={handleChangeCustomer} />
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Phone number</Form.Label>
                <Form.Control required type="text" placeholder='Phone number' name='phoneNumber' onChange={handleChangeCustomer} />
            </Form.Group>
        </Row>
        <Row className="mb-3">
            <Button type="submit">Submit</Button>
        </Row>
    </Form>
}
