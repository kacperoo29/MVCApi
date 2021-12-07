import React from 'react'
import { FormattedNumber } from 'react-intl'
import { ProductDto } from '../api'

export function ProductSmall(props: { product: ProductDto}) {
    let product = props.product
    return (
        <>
            <div className="col-md-2">
                <img src={product.image!} alt={product.name + '_image'} className='img-fluid' />
            </div>
            <div className="col-md-6 product-detail">
                <h4>{product.name}</h4>
                <p>{product.description}</p>
            </div>
            <div className="col-md-2 product-price">
                <FormattedNumber value={product.price?.value!} style={`currency`} currency={product.price?.currency?.code!} />
            </div>
        </>
    )
}