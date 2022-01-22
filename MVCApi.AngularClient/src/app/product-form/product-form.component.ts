import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateProduct, ProductService } from 'src/api';
import { isEmpty } from 'src/util';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
})

export class ProductFormComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    image: new FormControl('', Validators.required),
    price: new FormControl('', [Validators.required, Validators.min(0)])
  });
  submitted = false;

  constructor(
    private readonly productService: ProductService,
    private readonly authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  submit(): void {
    this.submitted = true;
    var createProduct: CreateProduct = this.form.value;
    if (this.form.valid) {
      this.productService
        .apiProductCreateProductPost(createProduct)
        .subscribe({
          //Add auth?
          next: () => {
            this.router.navigate(['/', 'products']);
            console.log('Added')
          },
          error: (err) => console.log(err),
        });
    }
  }

  get f(): { [key: string]: AbstractControl; }
  {
    return this.form.controls;
  }
}
