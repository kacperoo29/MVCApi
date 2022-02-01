import { getLocaleCurrencyCode } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import jsPDF from 'jspdf';
import { Observable } from 'rxjs';
import { ProductDtoIPaginatedList } from 'src/api';

@Component({
  selector: 'app-products-pdf',
  templateUrl: './products-pdf.component.html',
  styleUrls: ['./products-pdf.component.css']
})
export class ProductsPdfComponent implements OnInit {

  @ViewChild('pdfTable', {static: false}) pdfTable: ElementRef | undefined;
  @Input() products: Observable<ProductDtoIPaginatedList> | undefined;
  currency: string = getLocaleCurrencyCode(navigator.language) ?? "PLN";

  constructor() { }

  ngOnInit(): void {
  }

  public downloadAsPDF() {
    const doc = new jsPDF('p','pt', 'a4');

    const specialElementHandlers = {
      '#editor': function (element: any, renderer: any) {
        return true;
      }
    };

    const pdfTable = this.pdfTable?.nativeElement;
    doc.setFontSize(4);

    doc.html(pdfTable.innerHTML, {
      callback: function (doc) {
        doc.save('PriceListToPdf.pdf');
      }
   });
  }
}
