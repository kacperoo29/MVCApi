import moment from 'moment'
import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { AddressDto } from '../api/index'
import axios from "axios";
import { useParams } from 'react-router';

// TODO: Some nicer way to pick address and phone number

interface EditAddressErrors {
    country?: string | null,
    city?: string | null,
    street?: string | null,
    streetNumber?: string | null,
    postCode?: string | null,
}

export default function AddressEdit(props: any) {
    const { id } = useParams();
    const [address, setAddress] = useState<AddressDto>({})
    const [errors, setErrors] = useState<EditAddressErrors>({})
    
    var requestId = "";

    if(id!==undefined){
        requestId = id;
    }

    useEffect(() =>
    {
        axios.get<AddressDto>(`http://localhost:5000/api/Address/GetAddressById/${id}`)
            .then(response => {
                setAddress(response.data)
            })
    }, [])

    const validation = (): boolean => {
        let valid = true
        let newErrors: EditAddressErrors = {}

        if (!address.country) {
            newErrors.country = "Value name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!address.city) {
            newErrors.city = "Value must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!address.street) {
            newErrors.street = "Value must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!address.streetNumber) {
            newErrors.streetNumber = "Value must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!address.postCode) {
            newErrors.postCode = "Value must be set"
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
            try {
                const response = await axios.put(`http://localhost:5000/api/Address/EditAddress/${id}`, address)
            } catch (e) {
                console.log(e)
            }
        }
    }

    const handleChangeAddress = (event: { target: { name: any; value: any; }; }) => {
        setAddress({
          ...address,
          [event.target.name]: event.target.value
        });
    }

    return <Form noValidate onSubmit={handleSubmit}>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Country</Form.Label>
                <Form.Control defaultValue={address.country?.toString()} isInvalid={!!errors['country']} required type="text" placeholder='Country' name='country' onChange={handleChangeAddress} />
                <Form.Control.Feedback type='invalid'>{errors['country']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>City</Form.Label>
                <Form.Control defaultValue={address.city?.toString()} isInvalid={!!errors['city']} required type="text" placeholder='City' name='city' onChange={handleChangeAddress} />
                <Form.Control.Feedback type='invalid'>{errors['city']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Street</Form.Label>
                <Form.Control defaultValue={address.street?.toString()} isInvalid={!!errors['street']} required type="text" placeholder='Street' name='street' onChange={handleChangeAddress} />
                <Form.Control.Feedback type='invalid'>{errors['street']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Street Number</Form.Label>
                <Form.Control defaultValue={address.streetNumber?.toString()} isInvalid={!!errors['streetNumber']} required type="text" placeholder='Street Number' name='streetNumber' onChange={handleChangeAddress} />
                <Form.Control.Feedback type='invalid'>{errors['streetNumber']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Post code</Form.Label>
                <Form.Control defaultValue={address.postCode?.toString()} isInvalid={!!errors['postCode']} required type="text" placeholder='Post code' name='postCode' onChange={handleChangeAddress} />
                <Form.Control.Feedback type='invalid'>{errors['postCode']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-3">
            <Button type="submit">Submit</Button>
        </Row>
    </Form>
}