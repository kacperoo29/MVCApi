import React, { useEffect, useState } from 'react'
import { ProductDto, ProductApi, CartApi, ProductDtoIPaginatedList } from '../api'
import { getOrCreateCart } from '../util/CartUtil';
import { useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'
import ProductSmall from './ProductSmall'
import Pagination from './Pagination'

type ProductsProps = {

}

export default function Products() {
    const [products, setProducts] = useState<ProductDto[] | []>([])
    const [pagination, setPagination] = useState<ProductDtoIPaginatedList>({})
    const [page, setPage] = useState<Number>(1)
    const [pageSize, setPageSize] = useState<Number>(25)
    const intl = useIntl()

    useEffect((api = new ProductApi()) => {
        // api.apiProductGetAllProductsGet({ currencyCode: LocaleCurrency.getCurrency(intl.locale) })
        //     .then(response => setProducts(response))
        api.apiProductGetPaginatedProductsGet({
            pageNumber: page.valueOf(),
            pageSize: pageSize.valueOf(),
            currencyCode: LocaleCurrency.getCurrency(intl.locale)
        }).then(response => {
            setPagination(response)
            setProducts(response.items!)
        })
    }, [intl.locale]);

    const handleAdd = (e: React.MouseEvent<HTMLElement>, productId: string) => {
        const api = new CartApi()

        getOrCreateCart(LocaleCurrency.getCurrency(intl.locale))
            .then(response => {
                if (response.products?.filter(p => p.product?.id === productId).length === 0) {
                    api.apiCartAddProductToCartPut({ addProductToCart: { cartId: response.id, productId: productId, count: 1 } })
                        .catch(e => console.log(e))
                }
            })
            .catch(e => console.log(e))
    }

    return (
        <>
            {products.map(product => (
                <div key={product.id} className="row product">
                    <ProductSmall product={product} />
                    <div className="col-md-2">
                        <button className='btn btn-primary' onClick={(e) => handleAdd(e, product.id!)}>Add to cart</button>
                    </div>
                </div>
            ))}
            <Pagination
                pageIndex={pagination.pageIndex?.valueOf()!}
                totalPages={pagination.totalPages?.valueOf()!}
                hasNextPage={pagination.hasNextPage!}
                hasPreviousPage={pagination.hasPreviousPage!}/>
        </>
    );
}