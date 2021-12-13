import React, { useState, useEffect } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { ProductDto, ProductApi } from '../api/index'
import { useHistory, useParams } from "react-router-dom";


// TODO: Some nicer way to pick address and phone number

interface CreateProductErrors {
    name?: string | null,
    description?: string | null,
    image?: string | null,
}

export function ProductEdit(props: { id: string }) {
    const { id }: { id: string} = useParams();
    const [product, setProduct] = useState<ProductDto>({})
    const [errors, setErrors] = useState<CreateProductErrors>({});
    const history = useHistory();

    useEffect(() => {
        const api = new ProductApi()
        api.apiProductGetProductByIdIdGet({ id: id, currencyCode: "PLN" })
            .then(response => {
                setProduct(response);
            })
    }, [id])

    const validation = (): boolean => {
        let valid = true
        let newErrors: CreateProductErrors = {}

        if (!product.name) {
            newErrors.name = "Name must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!product.description) {
            newErrors.description= "Description must be set"
            valid = false
        } else {
            // Additional checks
        }

        if (!product.image) {
            newErrors.image= "Image must be set"
            valid = false
        } else {
            // Additional checks
        }

        setErrors(newErrors)
        return valid
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        const api = new ProductApi()
        event.preventDefault()
        event.stopPropagation()

        if (validation()) {
            try {
                api.apiProductEditProductIdPut({ id: id, editProduct: product })
                    .then(r => history.push('/products'))
            } catch (e) {
                console.log(e)
            }
        }
        
    }

    const handleChangeProduct = (event: React.ChangeEvent<HTMLInputElement>) => {
            setProduct({ ...product, [event.target.name]: event.target.value })
    }

    return <Form noValidate onSubmit={e => handleSubmit(e)}>
        <Row className="mb-2">
            <Form.Group as={Col}>
                <Form.Label>Product name</Form.Label>
                <Form.Control isInvalid={!!errors['name']} defaultValue={product.name?.toString()} required type="text" placeholder='Product name' name='name' onChange={handleChangeProduct} />
                <Form.Control.Feedback type='invalid'>{errors['name']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Product Description</Form.Label>
                <Form.Control isInvalid={!!errors['description']} defaultValue={product.description?.toString()} required type="text" placeholder='Description' name='description' onChange={handleChangeProduct} />
                <Form.Control.Feedback type='invalid'>{errors['description']}</Form.Control.Feedback>
            </Form.Group>
            <Form.Group as={Col}>
                <Form.Label>Product image</Form.Label>
                <Form.Control isInvalid={!!errors['image']} defaultValue={product.image?.toString()} required type="text" name='image' onChange={handleChangeProduct} />
                <Form.Control.Feedback type='invalid'>{errors['image']}</Form.Control.Feedback>
            </Form.Group>
        </Row>
        <Row className="mb-3">
            <Button type="submit">Submit</Button>
        </Row>
    </Form>
}
