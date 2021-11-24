import React, { useEffect, useState } from 'react'
import { ProductDto, ProductApi, CartApi } from '../api'
import { getOrCreateCart } from '../util/CartUtil';
import { FormattedNumber, useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'

export default function Products() {
    const [products, setProducts] = useState<ProductDto[] | []>([])
    const intl = useIntl()

    useEffect((api = new ProductApi()) => {
        api.apiProductGetAllProductsGet({ currencyCode: LocaleCurrency.getCurrency(intl.locale) }).then(response => setProducts(response))
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
                    <div className="col-md-6 product-detail">
                        <h4>{product.name}</h4>
                        <p>{product.description}</p>
                    </div>
                    <div className="col-md-2 product-price">                        
                        <FormattedNumber value={product.price?.value!} style='currency' currency={product.price?.currency?.code!} />                        
                    </div>
                    <div className="col-md-2">
                        <button className='btn btn-primary' onClick={async () => await handleAdd(product.id!)}>Add to cart</button>
                    </div>
                </div>
            ))}
        </>
    );
}