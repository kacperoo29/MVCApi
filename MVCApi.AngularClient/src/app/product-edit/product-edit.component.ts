import { getLocaleCurrencyCode } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { EditProduct, ProductDto, ProductService } from 'src/api';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    image: new FormControl('', Validators.required),
  });

  constructor(
    private readonly productService: ProductService,
    private readonly authService: AuthService,
    private readonly route: ActivatedRoute,
    private router: Router
  ) {}

  productId: string = "";
  product: Observable<ProductDto> | null = null;

  ngOnInit(): void {
    this.productId = <string>this.route.snapshot.paramMap.get('productId')?.toString();
    this.fetchProducts();
  }

  submit(): void {
    var editCustomer: EditProduct = this.form.value;
    if (this.form.valid) {
      this.productService
        .apiProductEditProductIdPut(this.productId, editCustomer)
        .subscribe({
          next: (res) => {
            this.router.navigate(['/', 'products']);
            console.log('Added')
          },
        });
    }
  }

  private fetchProducts(): void {
    this.product = this.productService.apiProductGetProductByIdIdGet(
      this.productId, 
      getLocaleCurrencyCode(navigator.language) ?? 'PLN'
    )
    this.product.subscribe(
      res => {
        this.form.patchValue({name: res.name});
        this.form.patchValue({description: res.description});
        this.form.patchValue({image: res.image});
      }
    )
  }

}
