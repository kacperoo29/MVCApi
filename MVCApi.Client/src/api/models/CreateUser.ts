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
 * @interface CreateUser
 */
export interface CreateUser {
    /**
     * 
     * @type {string}
     * @memberof CreateUser
     */
    email?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateUser
     */
    userName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateUser
     */
    password?: string | null;
}

export function CreateUserFromJSON(json: any): CreateUser {
    return CreateUserFromJSONTyped(json, false);
}

export function CreateUserFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateUser {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'email': !exists(json, 'email') ? undefined : json['email'],
        'userName': !exists(json, 'userName') ? undefined : json['userName'],
        'password': !exists(json, 'password') ? undefined : json['password'],
    };
}

export function CreateUserToJSON(value?: CreateUser | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'email': value.email,
        'userName': value.userName,
        'password': value.password,
    };
}


