import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CategoryDto,
  CategoryService,
  ProductDto,
  ProductDtoIPaginatedList,
  ProductService,
} from 'src/api';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  // TODO: Pagination
  products: Observable<ProductDto[]> =
    this.productService.apiProductGetAllProductsGet('PLN');
  // TODO: Change category depending on selected
  categories: Observable<CategoryDto[]> =
    this.categoryService.apiCategoryGetRootCategoriesGet();
  // TODO: Take optional category id as input
  
  constructor(
    private readonly productService: ProductService,
    private readonly categoryService: CategoryService
  ) {}

  ngOnInit(): void {}
}
