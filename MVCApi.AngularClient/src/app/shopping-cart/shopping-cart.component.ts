import { getLocaleCurrencyCode } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CartService, ShoppingCartDto } from 'src/api';
import { ShoppingCartService } from '../shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css'],
})
export class ShoppingCartComponent implements OnInit {
  $cart: ShoppingCartDto | null = null;
  isLoading: boolean = true;
  total: number = 0;
  currency: string = getLocaleCurrencyCode(navigator.language) ?? 'PLN';

  constructor(
    private readonly service: ShoppingCartService,
    private readonly cartService: CartService
  ) {
    this.service.getOrCreateCart().then((cart) => {
      this.isLoading = false;
      this.$cart = cart;
      this.total = this.calculateTotal();
    });
  }

  ngOnInit(): void {}

  private calculateTotal(): number {
    let lTotal = 0;
    this.$cart?.products?.forEach((p) => {
      lTotal += p.count! * p.product?.price?.value!;
    });

    return lTotal;
  }

  removeFromCart(productId?: string | undefined) {
    if (!productId) return;

    this.cartService
      .apiCartRemoveProductDelete({
        productId: productId,
        cartId: this.$cart?.id,
      })
      .subscribe({
        next: () => {
          if (this.$cart)
            this.$cart.products = this.$cart?.products?.filter(
              (product) => product.product?.id !== productId
            );
          this.total = this.calculateTotal();
        },
        error: (err) => console.log(err),
      });
  }

  onCountChange($event: Event, productId?: string | undefined) {
    if (!productId) return;

    var eventTarget = $event.target as HTMLInputElement;
    var newCount = eventTarget.valueAsNumber;

    this.cartService
      .apiCartChangeProductCountPut({
        productId: productId,
        count: newCount,
        cartId: this.$cart?.id,
      })
      .subscribe({
        next: () => {
          if (this.$cart && this.$cart.products)
          {
            var idx = this.$cart.products.findIndex(x => x.product?.id == productId)
            this.$cart.products[idx].count = newCount
          }
          this.total = this.calculateTotal();
        },
        error: (err) => console.log(err)
      });
  }
}
