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

/**
 * 
 * @export
 * @enum {string}
 */
export enum OrderState {
    NUMBER_0 = 0,
    NUMBER_1 = 1,
    NUMBER_2 = 2
}

export function OrderStateFromJSON(json: any): OrderState {
    return OrderStateFromJSONTyped(json, false);
}

export function OrderStateFromJSONTyped(json: any, ignoreDiscriminator: boolean): OrderState {
    return json as OrderState;
}

export function OrderStateToJSON(value?: OrderState | null): any {
    return value as any;
}
