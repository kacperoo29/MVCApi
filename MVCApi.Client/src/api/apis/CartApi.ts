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
    ShoppingCartDto,
    ShoppingCartDtoFromJSON,
    ShoppingCartDtoToJSON,
} from '../models';

export interface ApiCartAddProductToCartPutRequest {
    addProductToCart?: AddProductToCart;
}

export interface ApiCartCreateCartPostRequest {
    body?: object;
}

export interface ApiCartGetCartByIdCartIdGetRequest {
    cartId: string;
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
    async apiCartGetCartByIdCartIdGetRaw(requestParameters: ApiCartGetCartByIdCartIdGetRequest): Promise<runtime.ApiResponse<ShoppingCartDto>> {
        if (requestParameters.cartId === null || requestParameters.cartId === undefined) {
            throw new runtime.RequiredError('cartId','Required parameter requestParameters.cartId was null or undefined when calling apiCartGetCartByIdCartIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Cart/GetCartById/{CartId}`.replace(`{${"CartId"}}`, encodeURIComponent(String(requestParameters.cartId))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        });

        return new runtime.JSONApiResponse(response, (jsonValue) => ShoppingCartDtoFromJSON(jsonValue));
    }

    /**
     */
    async apiCartGetCartByIdCartIdGet(requestParameters: ApiCartGetCartByIdCartIdGetRequest): Promise<ShoppingCartDto> {
        const response = await this.apiCartGetCartByIdCartIdGetRaw(requestParameters);
        return await response.value();
    }

}