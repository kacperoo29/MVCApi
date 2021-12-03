/* tslint:disable */
/* eslint-disable */
/**
 * MVCApi
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import {
    AddProductToCart,
    AddProductToCartFromJSON,
    AddProductToCartToJSON,
    ChangeProductCountInCart,
    ChangeProductCountInCartFromJSON,
    ChangeProductCountInCartToJSON,
    ShoppingCartDto,
    ShoppingCartDtoFromJSON,
    ShoppingCartDtoToJSON,
} from '../models';

export interface ApiCartAddProductToCartPutRequest {
    addProductToCart?: AddProductToCart;
}

export interface ApiCartChangeProductCountPutRequest {
    changeProductCountInCart?: ChangeProductCountInCart;
}

export interface ApiCartCreateCartPostRequest {
    body?: object;
}

export interface ApiCartGetCartByIdIdGetRequest {
    id: string;
    currencyCode?: string | null;
}

/**
 * 
 */
export class CartApi extends runtime.BaseAPI {

    /**
     */
    async apiCartAddProductToCartPutRaw(requestParameters: ApiCartAddProductToCartPutRequest): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Cart/AddProductToCart`,
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: AddProductToCartToJSON(requestParameters.addProductToCart),
        });

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiCartAddProductToCartPut(requestParameters: ApiCartAddProductToCartPutRequest): Promise<string> {
        const response = await this.apiCartAddProductToCartPutRaw(requestParameters);
        return await response.value();
    }

    /**
     */
    async apiCartChangeProductCountPutRaw(requestParameters: ApiCartChangeProductCountPutRequest): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Cart/ChangeProductCount`,
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ChangeProductCountInCartToJSON(requestParameters.changeProductCountInCart),
        });

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiCartChangeProductCountPut(requestParameters: ApiCartChangeProductCountPutRequest): Promise<string> {
        const response = await this.apiCartChangeProductCountPutRaw(requestParameters);
        return await response.value();
    }

    /**
     */
    async apiCartCreateCartPostRaw(requestParameters: ApiCartCreateCartPostRequest): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Cart/CreateCart`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: requestParameters.body as any,
        });

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiCartCreateCartPost(requestParameters: ApiCartCreateCartPostRequest): Promise<string> {
        const response = await this.apiCartCreateCartPostRaw(requestParameters);
        return await response.value();
    }

    /**
     */
    async apiCartGetCartByIdIdGetRaw(requestParameters: ApiCartGetCartByIdIdGetRequest): Promise<runtime.ApiResponse<ShoppingCartDto>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiCartGetCartByIdIdGet.');
        }

        const queryParameters: any = {};

        if (requestParameters.currencyCode !== undefined) {
            queryParameters['currencyCode'] = requestParameters.currencyCode;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Cart/GetCartById/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        });

        return new runtime.JSONApiResponse(response, (jsonValue) => ShoppingCartDtoFromJSON(jsonValue));
    }

    /**
     */
    async apiCartGetCartByIdIdGet(requestParameters: ApiCartGetCartByIdIdGetRequest): Promise<ShoppingCartDto> {
        const response = await this.apiCartGetCartByIdIdGetRaw(requestParameters);
        return await response.value();
    }

}
