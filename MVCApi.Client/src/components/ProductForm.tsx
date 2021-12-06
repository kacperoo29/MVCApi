import React, { useState } from 'react'
import { Form, Row, Col, Button } from 'react-bootstrap'
import { CreateProduct, ProductApi } from '../api/index'

interface CreateProductErrors {
    name?: string | null,
    description?: string | null,
    image?: string | null,
    price?: string | null,
}

export function ProductForm(props: any) {

    const [product, setProduct] = useState<CreateProduct>({})
    const [errors, setErrors] = useState<CreateProductErrors>({})

    const validation = (): boolean => {

        let valid = true;
        let newErrors: CreateProductErrors = {};

        if (!product.name) {
            newErrors.name = "Product name must be set!";
            valid = false;
        } else {
            // Additional checks
        }

        if (!product.description) {
            newErrors.description = "Description must be set!";
            valid = false;
        } else {
            // Additional checks
        }

        if (!product.image) {
            newErrors.image = "Product image must be set!";
            valid = false;
        } else {
            // Additional checks
        }

        if (!product.price) {
            newErrors.price = "Product image must be set!";
            valid = false;
        } else {
            if (product.price.valueOf() < 0) {
                newErrors.price = "Price must be greater than 0";
                valid = false;
            }
        }
        setErrors(newErrors)

        return valid;
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        event.stopPropagation()

        if (validation()) {
            let api = new ProductApi()
            //console.log(customer.dateOfBirth)
            try {
                await api.apiProductCreateProductPost({ createProduct: product })
            } catch (e) {
                console.log(e)
            }
        }
    }

    const handleChangeProduct = (event: React.ChangeEvent<HTMLInputElement>) => {
        setProduct({ ...product, [event.target.name]: event.target.value })
    }

    return (

        <Form onSubmit={handleSubmit}>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product name</Form.Label>
                    <Form.Control isInvalid={!!errors['name']} required type="text" placeholder='Name of a product' name='name' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['name']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product description</Form.Label>
                    <Form.Control isInvalid={!!errors['description']} required type="text" placeholder='Product description' name='description' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['description']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product image</Form.Label>
                    <Form.Control isInvalid={!!errors['image']} required type="text" placeholder='Product image file' name='image' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['image']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-2">
                <Form.Group as={Col}>
                    <Form.Label>Product price</Form.Label>
                    <Form.Control isInvalid={!!errors['price']} required type="number" step="0.01" placeholder='0' name='price' onChange={handleChangeProduct} />
                    <Form.Control.Feedback type='invalid'>{errors['price']}</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className="mb-3">
                <Button type="submit">Submit</Button>
            </Row>
        </Form>
    );

}