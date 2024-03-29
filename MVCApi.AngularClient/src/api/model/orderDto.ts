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
import { ShoppingCartDto } from './shoppingCartDto';
import { CustomerDto } from './customerDto';
import { OrderState } from './orderState';


export interface OrderDto { 
    id?: string;
    customer?: CustomerDto;
    shoppingCart?: ShoppingCartDto;
    orderState?: OrderState;
    dateCreated?: string;
}

