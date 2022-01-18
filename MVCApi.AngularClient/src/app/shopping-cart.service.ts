import { getLocaleCurrencyCode } from '@angular/common';
import { compileDeclareFactoryFunction } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { CartService, ShoppingCartDto } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {

  constructor(private readonly api: CartService) {}

  async getOrCreateCart(): Promise<ShoppingCartDto | null> {
    let cartId: string | null = localStorage.getItem('cartId');
    var cart: ShoppingCartDto | null = null;

    if (!cartId) {
      cartId = await firstValueFrom(this.api.apiCartCreateCartPost());
      localStorage.setItem('cartId', cartId)
    }

    if (cartId) {
      try {
        cart = await firstValueFrom(
          this.api.apiCartGetCartByIdIdGet(
            cartId,
            getLocaleCurrencyCode(navigator.language) ?? 'PLN'
          )
        );
      } catch (e) {
        console.log(e);
      }
    }

    return cart;
  }

  clearCart() {
    localStorage.removeItem('cartId')
  }
}
