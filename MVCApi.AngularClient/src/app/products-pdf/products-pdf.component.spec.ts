import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsPdfComponent } from './products-pdf.component';

describe('ProductsPdfComponent', () => {
  let component: ProductsPdfComponent;
  let fixture: ComponentFixture<ProductsPdfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsPdfComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsPdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
