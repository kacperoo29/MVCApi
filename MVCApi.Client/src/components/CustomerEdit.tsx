import moment from 'moment'
import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CustomerDto, CustomerApi } from '../api/index'
import axios from "axios";
import { useParams } from 'react-router';

// TODO: Some nicer way to pick address and phone number

interface EditCustomerErrors {
    firstName?: string | null,
    lastName?: string | null,
    dateOfBirth?: string | null,
    country?: string | null,
    city?: string | null,
    street?: string | null,
    streetNumber?: string | null,
    postCode?: string | null,
    email?: string | null,
    phoneNumber?: string | null
}

export default function CustomerEdit(props: any) {
    //const [customer, setCustomer] = useState<EditCustomer>({})
    const { id } = useParams();
    const [customer, setCustomer] = useState<CustomerDto>({})
    const [errors, setErrors] = useState<EditCustomerErrors>({})
    const [formValue, setformValue] = useState({
        firstName: '',
        lastName: '',
        dateOfBirth: '',
        country: '',
        city: '',
        street: '',
        streetNumber: '',
        postCode: '',
        email: '',
        phoneNumber: '',
    });
    

    useEffect(() =>
    {
        axios.get<CustomerDto>(`http://localhost:5000/api/Customer/GetCustomerById/${id}`)
            .then(response => {
                setCustomer(response.data)
            })
    }, [])

    const validation = (): boolean => {
        let valid = true
        let newErrors: EditCustomerErrors = {}

        if (!formValue.firstName) {
            newErrors.firstName = "First name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.lastName) {
            newErrors.lastName = "Last name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.dateOfBirth) {
            newErrors.dateOfBirth = "Date of birth must be set"
            valid = false
        } else {         
            if (moment().diff(moment(formValue.dateOfBirth), 'year') < 18) {
                newErrors.dateOfBirth = "You must be older than 18"
                valid = false
            }
            // Additional checks
        }

        if (!formValue.country) {
            newErrors.country = "Country must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.city) {
            newErrors.city = "City must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.street) {
            newErrors.street = "Street must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.streetNumber) {
            newErrors.streetNumber = "Street number must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.postCode) {
            newErrors.postCode = "Post code must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!formValue.email) {
            newErrors.email = "Email must be set"
            valid = false
        } else {
            const emailRegex = /^(([^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*)|(".+"))@(([^<>()[\].,;:\s@"]+\.)+[^<>()[\].,;:\s@"]{2,})$/i;
            if (!emailRegex.test(formValue.email)) {
                newErrors.email = "Email must have a proper format"
                valid = false
            }
            // Additional checks
        }

        if (!formValue.phoneNumber) {
            newErrors.phoneNumber = "Phone number must be set"
            valid = false
        } else {
            // Additional checks
        }

        setErrors(newErrors)
        return valid
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        event.stopPropagation()

        if (validation()) {
            let api = new CustomerApi()
            //console.log(customer.dateOfBirth)
            try {
                const response = await axios.put(`http://localhost:5000/api/Customer/EditCustomer/${id}`, formValue)
            } catch (e) {
                console.log(e)
            }
        }
    }

    const handleChangeCustomer = (event: { target: { name: any; value: any; }; }) => {
        setformValue({
          ...formValue,
          [event.target.name]: event.target.value
        });
    }

    return <Form noValidate onSubmit={handleSubmit}>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>First name</Form.Label>
                <Form.Control value={customer.firstName?.toString()} isInvalid={!!errors['firstName']} required type="text" placeholder='First name' name='firstName' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['firstName']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Last name</Form.Label>
                <Form.Control value={customer.lastName?.toString()} isInvalid={!!errors['lastName']} required type="text" placeholder='Last name' name='lastName' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['lastName']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Date of birth</Form.Label>
                <Form.Control value={customer.dateOfBirth?.toString()} isInvalid={!!errors['dateOfBirth']} required type="date" name='dateOfBirth' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['dateOfBirth']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Country</Form.Label>
                <Form.Control value={customer.addresses?.pop()?.country?.toString()} isInvalid={!!errors['country']} required type="text" placeholder='Country' name='country' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['country']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>City</Form.Label>
                <Form.Control value={customer.addresses?.pop()?.city?.toString()} isInvalid={!!errors['city']} required type="text" placeholder='City' name='city' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['city']}</Form.Control.Feedback>
            </Form.Group>    
        </Row>
        <Row>
            <Form.Group as={Col}>
                <Form.Label>Street</Form.Label>
                <Form.Control value={customer.addresses?.pop()?.street?.toString()} isInvalid={!!errors['street']} required type="text" placeholder='Street' name='street' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['street']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group xs={1} as={Col}>
                <Form.Label>Street number</Form.Label>
                <Form.Control value={customer.addresses?.pop()?.streetNumber?.toString()} isInvalid={!!errors['streetNumber']} required type="text" placeholder='Street number' name='streetNumber' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['streetNumber']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group xs={2} as={Col}>
                <Form.Label>Post code</Form.Label>
                <Form.Control value={customer.addresses?.pop()?.postCode?.toString()} isInvalid={!!errors['postCode']} required type="text" placeholder='Post code' name='postCode' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['postCode']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Email</Form.Label>
                <Form.Control value={customer.contactInfos?.pop()?.email?.toString()} isInvalid={!!errors['email']} required type="email" placeholder='Email' name='email' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['email']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Phone number</Form.Label>
                <Form.Control value={customer.contactInfos?.pop()?.phoneNumber?.toString()} isInvalid={!!errors['phoneNumber']} required type="text" placeholder='Phone number' name='phoneNumber' onChange={handleChangeCustomer} />
                <Form.Control.Feedback type='invalid'>{errors['phoneNumber']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-3">
            <Button type="submit">Submit</Button>
        </Row>
    </Form>
}