import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateCustomer, CustomerService } from 'src/api';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    dateOfBirth: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    street: new FormControl('', Validators.required),
    streetNumber: new FormControl('', Validators.required),
    postCode: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required)
  })

  constructor(private readonly customerService: CustomerService) { }

  ngOnInit(): void {
  }

  submit(): void {
    var createCustomer: CreateCustomer = this.form.value
    if (this.form.valid) {
      var response = this.customerService.apiCustomerCreateCustomerPost(createCustomer)
    }
  }
}
