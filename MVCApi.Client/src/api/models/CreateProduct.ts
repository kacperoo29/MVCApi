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

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CreateProduct
 */
export interface CreateProduct {
    /**
     * 
     * @type {string}
     * @memberof CreateProduct
     */
    name?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateProduct
     */
    description?: string | null;
}

export function CreateProductFromJSON(json: any): CreateProduct {
    return CreateProductFromJSONTyped(json, false);
}

export function CreateProductFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateProduct {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'name': !exists(json, 'name') ? undefined : json['name'],
        'description': !exists(json, 'description') ? undefined : json['description'],
    };
}

export function CreateProductToJSON(value?: CreateProduct | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'name': value.name,
        'description': value.description,
    };
}

