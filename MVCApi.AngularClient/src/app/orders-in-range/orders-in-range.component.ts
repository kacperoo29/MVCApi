import { getLocaleCurrencyCode } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, combineLatest, forkJoin, Observable } from 'rxjs';
import { OrderDto, OrderService, ProductDto } from 'src/api';

interface ChartPoint {
  name: string;
  value: number;
}

interface ChartData {
  name: string;
  series: ChartPoint[];
}

@Component({
  selector: 'app-orders-in-range',
  templateUrl: './orders-in-range.component.html',
  styleUrls: ['./orders-in-range.component.css'],
})
export class OrdersInRangeComponent implements OnInit {
  startDateSubject: BehaviorSubject<Date> = new BehaviorSubject<Date>(
    new Date()
  );
  endDateSubject: BehaviorSubject<Date> = new BehaviorSubject<Date>(new Date());

  private orders: OrderDto[] | null = null;
  private orderMap: Map<Date, Map<ProductDto, number>> | null = null;
  private dateArray: Date[] | null = null;
  
  chartData: ChartData[] | null = null;

  constructor(private readonly orderService: OrderService) {
    combineLatest({
      startDate: this.startDateSubject,
      endDate: this.endDateSubject,
    }).subscribe((res) => {
      // this.dateArray = new Array<Date>();
      // var currentDate = res.startDate;
      // while (currentDate <= res.endDate) {
      //   this.dateArray.push(new Date(currentDate));
      //   currentDate.setDate(currentDate.getDate() + 1);
      // }

      this.orderService
        .apiOrderGetOrdersInDateRangeGet(
          new Date(res.startDate).toISOString(),
          new Date(res.endDate).toISOString(),
          getLocaleCurrencyCode(navigator.language) ?? 'PLN'
        )
        .subscribe((orders) => {
          var map = new Map<Date, Map<ProductDto, number>>();
          this.orders = orders;
          orders.forEach((order) => {
            order.shoppingCart?.products?.forEach((product) => {
              var currentDate = new Date(
                new Date(order.dateCreated!).toDateString()
              );
              var currentDateValue = map.get(currentDate);
              if (!currentDateValue) {
                map.set(currentDate, new Map<ProductDto, number>());
                currentDateValue = map.get(currentDate);
              }

              if (!currentDateValue) throw new Error();

              var currentCount = currentDateValue.get(product.product!);
              if (!currentCount) {
                currentDateValue.set(product.product!, product.count!);
              } else {
                currentDateValue.set(
                  product.product!,
                  currentCount + product.count!
                );
              }
            });
          });
          this.orderMap = map;
          this.createChartData();
        });
    });
  }

  ngOnInit(): void {}

  private createChartData() {
    var chartData: ChartData[] = new Array<ChartData>();
    if (this.orderMap) {
      this.orderMap.forEach((dateMap, date) => {
        dateMap.forEach((count, product) => {
          var data = chartData.find((x) => x.name == product.name);
          if (!data) {
            chartData.push({
              name: product.name!,
              series: new Array<ChartPoint>(),
            });
            data = chartData.find((x) => x.name == product.name);
          }

          if (!data) throw new Error();

          data.series.push({ name: date.toDateString(), value: count });
        });
      });
    }

    this.chartData = chartData;
  }
}
