import { getLocaleCurrencyCode } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { OrderDto, OrderService } from 'src/api';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent implements OnInit {
  order: Observable<OrderDto> | null = null;
  currency: string = getLocaleCurrencyCode(navigator.language) ?? 'PLN'

  constructor(
    private readonly orderService: OrderService,
    private readonly route: ActivatedRoute
  ) {
    var orderId = this.route.snapshot.paramMap.get('orderId')?.toString();
    if (orderId)
      this.order = this.orderService.apiOrderGetOrderByIdIdGet(
        orderId,
        getLocaleCurrencyCode(navigator.language) ?? 'PLN'
      );
  }

  ngOnInit(): void {}
}
