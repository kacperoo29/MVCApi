import React, { useEffect, useState } from 'react'
import { ProductDto, ProductApi, CartApi } from '../api'
import { getOrCreateCart } from '../util/CartUtil';
import { FormattedNumber, useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'

export default function Products() {
    const [products, setProducts] = useState<ProductDto[] | []>([])
    const intl = useIntl()

    useEffect((api = new ProductApi()) => {
        api.apiProductGetAllProductsGet().then(response => setProducts(response))
    }, []);

    const handleAdd = async (productId: string) => {
        let cartId = await getOrCreateCart()
        const api = new CartApi()
        let cart = await api.apiCartGetCartByIdCartIdGet({ cartId })

        if (cart.products?.filter(p => p.product?.id === productId).length === 0) {
            await api.apiCartAddProductToCartPut({ addProductToCart: { cartId: cartId, productId: productId, count: 1 } })
        }
    }
    
    return (
        <>
            {products.map(product => (
                <div key={product.id} className="row product">
                    <div className="col-md-2">
                        <img src={product.image!} alt={product.name + '_image'} className='img-fluid' />
                    </div>
                    <div className="col-md-7 product-detail">
                        <h4>{product.name}</h4>
                        <p>{product.description}</p>
                    </div>
                    <div className="col-md-2 product-price">                        
                        <FormattedNumber value={19.99} style='currency' currency={LocaleCurrency.getCurrency(intl.locale)} />                        
                    </div>
                    <div className="col-md-1">
                        <button className='btn btn-primary' onClick={async () => await handleAdd(product.id!)}>Add to cart</button>
                    </div>
                </div>
            ))}
        </>
    );
}