import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerDto, CustomerService } from 'src/api';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  $customers: Observable<CustomerDto[]> = this.customerService.apiCustomerGetAllCustomersGet()

  constructor(private readonly customerService: CustomerService) { 
    
  }

  ngOnInit(): void {
  }

}
