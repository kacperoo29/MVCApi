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
import { ProductDto } from './productDto';


export interface ProductDtoIPaginatedList { 
    readonly pageIndex?: number;
    readonly pageSize?: number;
    readonly totalPages?: number;
    readonly hasPreviousPage?: boolean;
    readonly hasNextPage?: boolean;
    readonly items?: Array<ProductDto> | null;
}

