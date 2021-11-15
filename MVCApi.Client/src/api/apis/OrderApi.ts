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
    CreateOrder,
    CreateOrderFromJSON,
    CreateOrderToJSON,
    OrderDto,
    OrderDtoFromJSON,
    OrderDtoToJSON,
} from '../models';

export interface ApiOrderCreateOrderPostRequest {
    createOrder?: CreateOrder;
}

export interface ApiOrderGetOrderByIdIdGetRequest {
    id: string;
}

/**
 * 
 */
export class OrderApi extends runtime.BaseAPI {

    /**
     */
    async apiOrderCreateOrderPostRaw(requestParameters: ApiOrderCreateOrderPostRequest): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/api/Order/CreateOrder`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateOrderToJSON(requestParameters.createOrder),
        });

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiOrderCreateOrderPost(requestParameters: ApiOrderCreateOrderPostRequest): Promise<string> {
        const response = await this.apiOrderCreateOrderPostRaw(requestParameters);
        return await response.value();
    }

    /**
     */
    async apiOrderGetAllOrdersGetRaw(): Promise<runtime.ApiResponse<Array<OrderDto>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Order/GetAllOrders`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        });

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(OrderDtoFromJSON));
    }

    /**
     */
    async apiOrderGetAllOrdersGet(): Promise<Array<OrderDto>> {
        const response = await this.apiOrderGetAllOrdersGetRaw();
        return await response.value();
    }

    /**
     */
    async apiOrderGetOrderByIdIdGetRaw(requestParameters: ApiOrderGetOrderByIdIdGetRequest): Promise<runtime.ApiResponse<OrderDto>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiOrderGetOrderByIdIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/Order/GetOrderById/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        });

        return new runtime.JSONApiResponse(response, (jsonValue) => OrderDtoFromJSON(jsonValue));
    }

    /**
     */
    async apiOrderGetOrderByIdIdGet(requestParameters: ApiOrderGetOrderByIdIdGetRequest): Promise<OrderDto> {
        const response = await this.apiOrderGetOrderByIdIdGetRaw(requestParameters);
        return await response.value();
    }

}