import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css'],
})
export class PaginationComponent implements OnInit {
  @Input() pageIndex: number = 1;
  @Input() totalPages: number = 1;
  @Input() hasPreviousPage: boolean = false;
  @Input() hasNextPage: boolean = false;

  rangeWithDots: Array<string | number> = [];

  constructor() {}

  ngOnInit(): void {
    this.calculateRange();
  }

  ngOnChange() {
    this.calculateRange();
  }

  private calculateRange() {
    var current = this.pageIndex,
      last = this.totalPages,
      delta = 2,
      left = current - delta,
      right = current + delta + 1,
      range = [],
      rangeWithDots = [],
      l;

    for (let i = 1; i <= last; i++) {
      if ((i === 1 || i === last || i >= left) && i < right) {
        range.push(i);
      }
    }

    for (let i of range) {
      if (l) {
        if (i - l === 2) {
          rangeWithDots.push(l + 1);
        } else if (i - l !== 1) {
          rangeWithDots.push('...');
        }
      }
      rangeWithDots.push(i);
      l = i;
    }

    console.log(rangeWithDots);
    this.rangeWithDots = rangeWithDots;
  }
}
