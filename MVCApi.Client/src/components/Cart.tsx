import React, { useEffect, useState } from 'react'
import { CartApi, ShoppingCartDto } from '../api'
import { getOrCreateCart } from '../util/CartUtil'
import { FormattedNumber, useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'
import ProductSmall from './ProductSmall'

export default function Cart() {
    const [cart, setCart] = useState<ShoppingCartDto>({})
    const [total, setTotal] = useState<Number>(0.0)
    const [changed, setChanged] = useState<boolean>(false)
    const intl = useIntl()

    useEffect(() => {
        getOrCreateCart(LocaleCurrency.getCurrency(intl.locale))
            .then(cart => {
                setCart(cart)
                let lTotal = 0
                cart.products?.forEach(p => {
                    lTotal += p.count! * p.product?.price?.value!
                })
                setTotal(lTotal)
                setChanged(false)
            }).catch(e => console.log(e))
    }, [intl.locale, changed])

    const changeCount = (e: React.ChangeEvent<HTMLInputElement>, productId: string) => {
        const api = new CartApi()
        api.apiCartChangeProductCountPut({
            changeProductCountInCart: {
                cartId: cart.id, productId: productId, count: e.target.valueAsNumber
            }
        }).then(response => {
            setChanged(true)
        }).catch(e => console.log(e))
    }

    return <div className='row'>
        <div className="col col-lg-9">
            {cart.products?.map(product => (
                <div key={product.product?.id} className="row product">
                    <ProductSmall product={product.product!} />
                    <div className="col-md-1">
                        <input className="form-control input-sm" type="number" min="1" step="1" value={product.count} onChange={e => changeCount(e, product.product?.id!)} />
                    </div>
                    <div className="col-md-1">
                        <button className="btn"><i className="bi bi-trash text-danger"></i></button>
                    </div>
                </div>
            ))}
        </div>
        <div className="col col-lg-3 product">
            <h4>
                Total price:
            </h4>
            <p className="product-price">
                <FormattedNumber value={total.valueOf()} style='currency' currency={LocaleCurrency.getCurrency(intl.locale)} />
            </p>
            <button className="btn btn-primary">Confirm order</button>
        </div>
    </div>

}