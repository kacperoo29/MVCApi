import { getLocaleCurrencyCode } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CartService,
  CategoryDto,
  CategoryService,
  ProductDto,
  ProductDtoIPaginatedList,
  ProductService,
} from 'src/api';
import { ShoppingCartService } from '../shopping-cart.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  // TODO: Pagination
  products: Observable<ProductDto[]> =
    this.productService.apiProductGetAllProductsGet(
      getLocaleCurrencyCode(navigator.language) ?? 'PLN'
    );
  // TODO: Change category depending on selected
  categories: Observable<CategoryDto[]> =
    this.categoryService.apiCategoryGetRootCategoriesGet();
  // TODO: Take optional category id as input

  constructor(
    private readonly productService: ProductService,
    private readonly categoryService: CategoryService,
    private readonly cartService: CartService,
    private readonly shoppingCartService: ShoppingCartService
  ) {}

  ngOnInit(): void {}

  addToCart(id: string | undefined) {
    if (!id) return;

    this.shoppingCartService.getOrCreateCart().then((cart) => {
      this.cartService
        .apiCartAddProductToCartPut({
          cartId: cart?.id,
          productId: id,
          count: 1,
        })
        .subscribe({
          next: () => console.log('Added'),
          error: (err) => console.log(err),
        });
    });
  }
}
