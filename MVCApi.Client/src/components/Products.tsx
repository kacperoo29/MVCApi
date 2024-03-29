import React, { useEffect, useState } from 'react'
import { ProductDto, ProductApi, CartApi, ProductDtoIPaginatedList, CategoryDto, CategoryApi } from '../api'
import { getOrCreateCart } from '../util/CartUtil';
import { useIntl } from 'react-intl'
import LocaleCurrency from 'locale-currency'
import { useLocation } from 'react-router';
import { ProductSmall, Pagination, CategoryTree } from './';
import { Link } from 'react-router-dom';

type ProductsProps = {
    categoryId?: string
}

export function Products() {
    const [products, setProducts] = useState<ProductDto[] | []>([])
    const [pagination, setPagination] = useState<ProductDtoIPaginatedList>({})
    const [page, setPage] = useState<Number>(1)
    const [pageSize, setPageSize] = useState<Number>(25)
    const intl = useIntl()
    const location = useLocation<ProductsProps>()
    const categoryId = location.state?.categoryId
    const [categories, setCategories] = useState<CategoryDto[]>([])

    useEffect((api = new ProductApi()) => {
        const categoryApi = new CategoryApi()
        const args: any = {
            pageNumber: page.valueOf(),
            pageSize: pageSize.valueOf(),
            currencyCode: LocaleCurrency.getCurrency(intl.locale)
        }

        if (categoryId) {
            args['categoryId'] = categoryId
            api.apiProductGetPaginatedProductsByCategoryGet(args)
                .then(response => {
                    setPagination(response)
                    setProducts(response.items!)
                })
            categoryApi.apiCategoryGetCategoryByIdIdGet({id: categoryId})
                .then(response => {
                    setCategories([response])
                })
        } else {
            api.apiProductGetPaginatedProductsGet(args)
                .then(response => {
                    setPagination(response)
                    setProducts(response.items!)
                })
            categoryApi.apiCategoryGetRootCategoriesGet()
                .then(response => {
                    setCategories(response)
                })
        }
    }, [intl.locale, page, pageSize, categoryId]);

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
            <div className="row">
                <div className="col-lg-3">                    
                    {categories.map(category =>
                        <CategoryTree category={category} />
                    )}
                </div>
                <div className="col-lg-9">
                    {products.map(product => (
                        <div key={product.id} className="row product">
                            <ProductSmall product={product} />
                            <div className="col-md-2">
                                <button className='btn btn-primary' onClick={(e) => handleAdd(e, product.id!)}>Add to cart</button>
                                <Link to={`/products/${product.id}/edit`}><button className='btn btn-primary'>Edit</button></Link>
                            </div>
                        </div>
                    ))}
                    <Link className='btn btn-primary' to="/products/create">Add product</Link>
                </div>                
            </div>
            <Pagination
                pageIndex={pagination.pageIndex?.valueOf()!}
                totalPages={pagination.totalPages?.valueOf()!}
                hasNextPage={pagination.hasNextPage!}
                hasPreviousPage={pagination.hasPreviousPage!}
                setPage={setPage}
                setPageSize={setPageSize}
            />
        </>
    );
}