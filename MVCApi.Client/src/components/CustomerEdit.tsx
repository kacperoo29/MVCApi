import moment from 'moment'
import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CustomerDto, CustomerApi } from '../api/index'
import { useParams } from 'react-router-dom';

// TODO: Some nicer way to pick address and phone number

interface EditCustomerErrors {
    firstName?: string | null,
    lastName?: string | null,
    dateOfBirth?: string | null,
}

export function CustomerEdit() {
    const { id }: any = useParams();
    const [customer, setCustomer] = useState<CustomerDto>({})
    const [errors, setErrors] = useState<EditCustomerErrors>({})

    var requestId = "";

    if (id !== undefined) {
        requestId = id;
    }

    console.log("Request id: " + requestId);
    useEffect((api = new CustomerApi()) => {
        api.apiCustomerGetCustomerByIdIdGet({ id: requestId }).then(response => setCustomer(response))
    }, [requestId]);

    console.log(customer.firstName);
    console.log(customer.dateOfBirth);
    console.log(moment(customer.dateOfBirth).format("YYYY-MM-DD"));

    const validation = (): boolean => {
        let valid = true
        let newErrors: EditCustomerErrors = {}

        if (!customer.firstName) {
            newErrors.firstName = "First name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!customer.lastName) {
            newErrors.lastName = "Last name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!customer.dateOfBirth) {
            newErrors.dateOfBirth = "Date of birth must be set"
            valid = false
        } else {
            if (moment().diff(moment(customer.dateOfBirth), 'year') < 18) {
                newErrors.dateOfBirth = "You must be older than 18"
                valid = false
            }
            // Additional checks
        }
        setErrors(newErrors)
        return valid
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        const api = new CustomerApi()
        event.preventDefault()
        event.stopPropagation()

        if (validation()) {
            try {
                await api.apiCustomerEditCustomerIdPut({ id: id, editCustomer: customer })
            } catch (e) {
                console.log(e)
            }
        }
    }

    const handleChangeCustomer = (event: { target: { name: any; value: any; }; }) => {
        setCustomer({
            ...customer,
            [event.target.name]: event.target.value
        });
    }

    return (
        <Form noValidate onSubmit={handleSubmit}>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>First name</Form.Label>
                    <Form.Control defaultValue={customer.firstName?.toString()} isInvalid={!!errors['firstName']} required type="text" placeholder='First name' name='firstName' onChange={handleChangeCustomer} />
                    <Form.Control.Feedback type='invalid'>{errors['firstName']}</Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col}>
                    <Form.Label>Last name</Form.Label>
                    <Form.Control defaultValue={customer.lastName?.toString()} isInvalid={!!errors['lastName']} required type="text" placeholder='Last name' name='lastName' onChange={handleChangeCustomer} />
                    <Form.Control.Feedback type='invalid'>{errors['lastName']}</Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col}>
                    <Form.Label>Date of birth</Form.Label>
                    <Form.Control defaultValue={moment(customer?.dateOfBirth).format("YYYY-MM-DD")} isInvalid={!!errors['dateOfBirth']} required type="date" name='dateOfBirth' onChange={handleChangeCustomer} />
                    <Form.Control.Feedback type='invalid'>{errors['dateOfBirth']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-3">
                <Button type="submit">Submit</Button>
            </Row>
        </Form>
    );
}