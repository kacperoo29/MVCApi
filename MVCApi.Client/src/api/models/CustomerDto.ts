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
import {
    AddressDto,
    AddressDtoFromJSON,
    AddressDtoFromJSONTyped,
    AddressDtoToJSON,
    ContactInfoDto,
    ContactInfoDtoFromJSON,
    ContactInfoDtoFromJSONTyped,
    ContactInfoDtoToJSON,
} from './';

/**
 * 
 * @export
 * @interface CustomerDto
 */
export interface CustomerDto {
    /**
     * 
     * @type {string}
     * @memberof CustomerDto
     */
    id?: string;
    /**
     * 
     * @type {string}
     * @memberof CustomerDto
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CustomerDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {Date}
     * @memberof CustomerDto
     */
    dateOfBirth?: Date;
    /**
     * 
     * @type {Array<AddressDto>}
     * @memberof CustomerDto
     */
    addresses?: Array<AddressDto> | null;
    /**
     * 
     * @type {Array<ContactInfoDto>}
     * @memberof CustomerDto
     */
    contactInfos?: Array<ContactInfoDto> | null;
}

export function CustomerDtoFromJSON(json: any): CustomerDto {
    return CustomerDtoFromJSONTyped(json, false);
}

export function CustomerDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CustomerDto {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': !exists(json, 'id') ? undefined : json['id'],
        'firstName': !exists(json, 'firstName') ? undefined : json['firstName'],
        'lastName': !exists(json, 'lastName') ? undefined : json['lastName'],
        'dateOfBirth': !exists(json, 'dateOfBirth') ? undefined : (new Date(json['dateOfBirth'])),
        'addresses': !exists(json, 'addresses') ? undefined : (json['addresses'] === null ? null : (json['addresses'] as Array<any>).map(AddressDtoFromJSON)),
        'contactInfos': !exists(json, 'contactInfos') ? undefined : (json['contactInfos'] === null ? null : (json['contactInfos'] as Array<any>).map(ContactInfoDtoFromJSON)),
    };
}

export function CustomerDtoToJSON(value?: CustomerDto | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'firstName': value.firstName,
        'lastName': value.lastName,
        'dateOfBirth': value.dateOfBirth === undefined ? undefined : (value.dateOfBirth.toISOString()),
        'addresses': value.addresses === undefined ? undefined : (value.addresses === null ? null : (value.addresses as Array<any>).map(AddressDtoToJSON)),
        'contactInfos': value.contactInfos === undefined ? undefined : (value.contactInfos === null ? null : (value.contactInfos as Array<any>).map(ContactInfoDtoToJSON)),
    };
}


