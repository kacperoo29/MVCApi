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
 * @interface EditCustomer
 */
export interface EditCustomer {
    /**
     * 
     * @type {string}
     * @memberof EditCustomer
     */
    customerId?: string;
    /**
     * 
     * @type {string}
     * @memberof EditCustomer
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof EditCustomer
     */
    lastName?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof EditCustomer
     */
    dateOfBirth?: Date;
}

export function EditCustomerFromJSON(json: any): EditCustomer {
    return EditCustomerFromJSONTyped(json, false);
}

export function EditCustomerFromJSONTyped(json: any, ignoreDiscriminator: boolean): EditCustomer {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'customerId': !exists(json, 'customerId') ? undefined : json['customerId'],
        'firstName': !exists(json, 'firstName') ? undefined : json['firstName'],
        'lastName': !exists(json, 'lastName') ? undefined : json['lastName'],
        'dateOfBirth': !exists(json, 'dateOfBirth') ? undefined : (new Date(json['dateOfBirth'])),
    };
}

export function EditCustomerToJSON(value?: EditCustomer | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'customerId': value.customerId,
        'firstName': value.firstName,
        'lastName': value.lastName,
        'dateOfBirth': value.dateOfBirth === undefined ? undefined : (value.dateOfBirth.toISOString()),
    };
}


