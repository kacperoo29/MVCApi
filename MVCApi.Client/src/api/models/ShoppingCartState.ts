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
export enum ShoppingCartState {
    NUMBER_0 = 0,
    NUMBER_1 = 1
}

export function ShoppingCartStateFromJSON(json: any): ShoppingCartState {
    return ShoppingCartStateFromJSONTyped(json, false);
}

export function ShoppingCartStateFromJSONTyped(json: any, ignoreDiscriminator: boolean): ShoppingCartState {
    return json as ShoppingCartState;
}

export function ShoppingCartStateToJSON(value?: ShoppingCartState | null): any {
    return value as any;
}

