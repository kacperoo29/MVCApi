import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { ContactInfoDto, ContactInfoApi } from '../api'
import { useParams, useHistory } from 'react-router';

// TODO: Some nicer way to pick address and phone number

interface EditContactInfoErrors {
    email?: string | null,
    phoneNumber?: string | null
}

export function ContactInfoEdit(props: { id: string }) {
    const { id }: { id: string} = useParams();
    const [contactInfo, setContactInfo] = useState<ContactInfoDto>({})
    const [errors, setErrors] = useState<EditContactInfoErrors>({})
    const history = useHistory();

    useEffect(() => {
        const api = new ContactInfoApi()
        api.apiContactInfoGetContactInfoByIdIdGet({ id: id })
            .then(response => {
                setContactInfo(response)
            })
    }, [id])

    const validation = (): boolean => {
        let valid = true
        let newErrors: EditContactInfoErrors = {}

        if (!contactInfo.email) {
            newErrors.email = "First name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!contactInfo.phoneNumber) {
            newErrors.phoneNumber = "Last name must be set"
            valid = false
        } else {
            // Additional checks
        }

        setErrors(newErrors)
        return valid
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        const api = new ContactInfoApi()
        event.preventDefault()
        event.stopPropagation()


        if (validation()) {
            try {
                api.apiContactInfoEditContactInfoIdPut({ id: id, editContactInfo: contactInfo })
                    .then(r => history.push('/'))
            } catch (e) {
                console.log(e)
            }
        }
    }

    const handleChangeContactInfo = (event: React.ChangeEvent<HTMLInputElement>) => {
        setContactInfo({
            ...contactInfo,
            [event.target.name]: event.target.value
        });
    }

    return <Form noValidate onSubmit={(e) => handleSubmit(e)}>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Email</Form.Label>
                <Form.Control defaultValue={contactInfo.email?.toString()} isInvalid={!!errors['email']} required type="text" placeholder='Email' name='email' onChange={handleChangeContactInfo} />
                <Form.Control.Feedback type='invalid'>{errors['email']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Phone number</Form.Label>
                <Form.Control defaultValue={contactInfo.phoneNumber?.toString()} isInvalid={!!errors['phoneNumber']} required type="text" placeholder='Phone number' name='phoneNumber' onChange={handleChangeContactInfo} />
                <Form.Control.Feedback type='invalid'>{errors['phoneNumber']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-3">
            <Button type="submit">Submit</Button>
        </Row>
    </Form>
}