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
/* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent, HttpParameterCodec, HttpContext 
        }       from '@angular/common/http';
import { CustomHttpParameterCodec }                          from '../encoder';
import { Observable }                                        from 'rxjs';

// @ts-ignore
import { ChangeOrderState } from '../model/changeOrderState';
// @ts-ignore
import { CreateOrder } from '../model/createOrder';
// @ts-ignore
import { OrderDto } from '../model/orderDto';

// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';



@Injectable({
  providedIn: 'root'
})
export class OrderService {

    protected basePath = 'http://localhost';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();
    public encoder: HttpParameterCodec;

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (configuration) {
            this.configuration = configuration;
        }
        if (typeof this.configuration.basePath !== 'string') {
            if (typeof basePath !== 'string') {
                basePath = this.basePath;
            }
            this.configuration.basePath = basePath;
        }
        this.encoder = this.configuration.encoder || new CustomHttpParameterCodec();
    }


    private addToHttpParams(httpParams: HttpParams, value: any, key?: string): HttpParams {
        if (typeof value === "object" && value instanceof Date === false) {
            httpParams = this.addToHttpParamsRecursive(httpParams, value);
        } else {
            httpParams = this.addToHttpParamsRecursive(httpParams, value, key);
        }
        return httpParams;
    }

    private addToHttpParamsRecursive(httpParams: HttpParams, value?: any, key?: string): HttpParams {
        if (value == null) {
            return httpParams;
        }

        if (typeof value === "object") {
            if (Array.isArray(value)) {
                (value as any[]).forEach( elem => httpParams = this.addToHttpParamsRecursive(httpParams, elem, key));
            } else if (value instanceof Date) {
                if (key != null) {
                    httpParams = httpParams.append(key,
                        (value as Date).toISOString().substr(0, 10));
                } else {
                   throw Error("key may not be null if value is Date");
                }
            } else {
                Object.keys(value).forEach( k => httpParams = this.addToHttpParamsRecursive(
                    httpParams, value[k], key != null ? `${key}.${k}` : k));
            }
        } else if (key != null) {
            httpParams = httpParams.append(key, value);
        } else {
            throw Error("key may not be null if value is not object or array");
        }
        return httpParams;
    }

    /**
     * @param changeOrderState 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiOrderChangeStatePut(changeOrderState?: ChangeOrderState, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<string>;
    public apiOrderChangeStatePut(changeOrderState?: ChangeOrderState, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<string>>;
    public apiOrderChangeStatePut(changeOrderState?: ChangeOrderState, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<string>>;
    public apiOrderChangeStatePut(changeOrderState?: ChangeOrderState, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarHeaders = this.defaultHeaders;

        let localVarCredential: string | undefined;
        // authentication (Bearer) required
        localVarCredential = this.configuration.lookupCredential('Bearer');
        if (localVarCredential) {
            localVarHeaders = localVarHeaders.set('Authorization', 'Bearer ' + localVarCredential);
        }

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Content-Type', httpContentTypeSelected);
        }

        let responseType_: 'text' | 'json' = 'json';
        if(localVarHttpHeaderAcceptSelected && localVarHttpHeaderAcceptSelected.startsWith('text')) {
            responseType_ = 'text';
        }

        return this.httpClient.put<string>(`${this.configuration.basePath}/api/Order/ChangeState`,
            changeOrderState,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param createOrder 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiOrderCreateOrderPost(createOrder?: CreateOrder, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<string>;
    public apiOrderCreateOrderPost(createOrder?: CreateOrder, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<string>>;
    public apiOrderCreateOrderPost(createOrder?: CreateOrder, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<string>>;
    public apiOrderCreateOrderPost(createOrder?: CreateOrder, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarHeaders = this.defaultHeaders;

        let localVarCredential: string | undefined;
        // authentication (Bearer) required
        localVarCredential = this.configuration.lookupCredential('Bearer');
        if (localVarCredential) {
            localVarHeaders = localVarHeaders.set('Authorization', 'Bearer ' + localVarCredential);
        }

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Content-Type', httpContentTypeSelected);
        }

        let responseType_: 'text' | 'json' = 'json';
        if(localVarHttpHeaderAcceptSelected && localVarHttpHeaderAcceptSelected.startsWith('text')) {
            responseType_ = 'text';
        }

        return this.httpClient.post<string>(`${this.configuration.basePath}/api/Order/CreateOrder`,
            createOrder,
            {
                context: localVarHttpContext,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param currencyCode 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiOrderGetAllOrdersGet(currencyCode?: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<Array<OrderDto>>;
    public apiOrderGetAllOrdersGet(currencyCode?: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<Array<OrderDto>>>;
    public apiOrderGetAllOrdersGet(currencyCode?: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<Array<OrderDto>>>;
    public apiOrderGetAllOrdersGet(currencyCode?: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarQueryParameters = new HttpParams({encoder: this.encoder});
        if (currencyCode !== undefined && currencyCode !== null) {
          localVarQueryParameters = this.addToHttpParams(localVarQueryParameters,
            <any>currencyCode, 'currencyCode');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarCredential: string | undefined;
        // authentication (Bearer) required
        localVarCredential = this.configuration.lookupCredential('Bearer');
        if (localVarCredential) {
            localVarHeaders = localVarHeaders.set('Authorization', 'Bearer ' + localVarCredential);
        }

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' = 'json';
        if(localVarHttpHeaderAcceptSelected && localVarHttpHeaderAcceptSelected.startsWith('text')) {
            responseType_ = 'text';
        }

        return this.httpClient.get<Array<OrderDto>>(`${this.configuration.basePath}/api/Order/GetAllOrders`,
            {
                context: localVarHttpContext,
                params: localVarQueryParameters,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param id 
     * @param currencyCode 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiOrderGetOrderByIdIdGet(id: string, currencyCode?: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<OrderDto>;
    public apiOrderGetOrderByIdIdGet(id: string, currencyCode?: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<OrderDto>>;
    public apiOrderGetOrderByIdIdGet(id: string, currencyCode?: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<OrderDto>>;
    public apiOrderGetOrderByIdIdGet(id: string, currencyCode?: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {
        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling apiOrderGetOrderByIdIdGet.');
        }

        let localVarQueryParameters = new HttpParams({encoder: this.encoder});
        if (currencyCode !== undefined && currencyCode !== null) {
          localVarQueryParameters = this.addToHttpParams(localVarQueryParameters,
            <any>currencyCode, 'currencyCode');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarCredential: string | undefined;
        // authentication (Bearer) required
        localVarCredential = this.configuration.lookupCredential('Bearer');
        if (localVarCredential) {
            localVarHeaders = localVarHeaders.set('Authorization', 'Bearer ' + localVarCredential);
        }

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' = 'json';
        if(localVarHttpHeaderAcceptSelected && localVarHttpHeaderAcceptSelected.startsWith('text')) {
            responseType_ = 'text';
        }

        return this.httpClient.get<OrderDto>(`${this.configuration.basePath}/api/Order/GetOrderById/${encodeURIComponent(String(id))}`,
            {
                context: localVarHttpContext,
                params: localVarQueryParameters,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * @param startDate 
     * @param endDate 
     * @param currencyCode 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiOrderGetOrdersInDateRangeGet(startDate?: string, endDate?: string, currencyCode?: string, observe?: 'body', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<Array<OrderDto>>;
    public apiOrderGetOrdersInDateRangeGet(startDate?: string, endDate?: string, currencyCode?: string, observe?: 'response', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpResponse<Array<OrderDto>>>;
    public apiOrderGetOrdersInDateRangeGet(startDate?: string, endDate?: string, currencyCode?: string, observe?: 'events', reportProgress?: boolean, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<HttpEvent<Array<OrderDto>>>;
    public apiOrderGetOrdersInDateRangeGet(startDate?: string, endDate?: string, currencyCode?: string, observe: any = 'body', reportProgress: boolean = false, options?: {httpHeaderAccept?: 'text/plain' | 'application/json' | 'text/json', context?: HttpContext}): Observable<any> {

        let localVarQueryParameters = new HttpParams({encoder: this.encoder});
        if (startDate !== undefined && startDate !== null) {
          localVarQueryParameters = this.addToHttpParams(localVarQueryParameters,
            <any>startDate, 'startDate');
        }
        if (endDate !== undefined && endDate !== null) {
          localVarQueryParameters = this.addToHttpParams(localVarQueryParameters,
            <any>endDate, 'endDate');
        }
        if (currencyCode !== undefined && currencyCode !== null) {
          localVarQueryParameters = this.addToHttpParams(localVarQueryParameters,
            <any>currencyCode, 'currencyCode');
        }

        let localVarHeaders = this.defaultHeaders;

        let localVarCredential: string | undefined;
        // authentication (Bearer) required
        localVarCredential = this.configuration.lookupCredential('Bearer');
        if (localVarCredential) {
            localVarHeaders = localVarHeaders.set('Authorization', 'Bearer ' + localVarCredential);
        }

        let localVarHttpHeaderAcceptSelected: string | undefined = options && options.httpHeaderAccept;
        if (localVarHttpHeaderAcceptSelected === undefined) {
            // to determine the Accept header
            const httpHeaderAccepts: string[] = [
                'text/plain',
                'application/json',
                'text/json'
            ];
            localVarHttpHeaderAcceptSelected = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        }
        if (localVarHttpHeaderAcceptSelected !== undefined) {
            localVarHeaders = localVarHeaders.set('Accept', localVarHttpHeaderAcceptSelected);
        }

        let localVarHttpContext: HttpContext | undefined = options && options.context;
        if (localVarHttpContext === undefined) {
            localVarHttpContext = new HttpContext();
        }


        let responseType_: 'text' | 'json' = 'json';
        if(localVarHttpHeaderAcceptSelected && localVarHttpHeaderAcceptSelected.startsWith('text')) {
            responseType_ = 'text';
        }

        return this.httpClient.get<Array<OrderDto>>(`${this.configuration.basePath}/api/Order/GetOrdersInDateRange`,
            {
                context: localVarHttpContext,
                params: localVarQueryParameters,
                responseType: <any>responseType_,
                withCredentials: this.configuration.withCredentials,
                headers: localVarHeaders,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
