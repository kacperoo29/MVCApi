import { getLocaleCurrencyCode } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ProductDto } from 'src/api';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product: ProductDto | undefined;

  currency: string = getLocaleCurrencyCode(navigator.language) ?? "PLN"

  constructor() { }

  ngOnInit(): void {
  }

}
