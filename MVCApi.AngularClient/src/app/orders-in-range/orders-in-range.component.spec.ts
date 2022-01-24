import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersInRangeComponent } from './orders-in-range.component';

describe('OrdersInRangeComponent', () => {
  let component: OrdersInRangeComponent;
  let fixture: ComponentFixture<OrdersInRangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersInRangeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersInRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
