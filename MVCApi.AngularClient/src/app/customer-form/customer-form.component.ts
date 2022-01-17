import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateCustomer, CustomerService } from 'src/api';
import { isEmpty } from 'src/util';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css'],
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
    phoneNumber: new FormControl('', Validators.required),
  });

  constructor(
    private readonly customerService: CustomerService,
    private readonly authService: AuthService
  ) {}

  ngOnInit(): void {}

  submit(): void {
    var createCustomer: CreateCustomer = this.form.value;
    if (this.form.valid) {
      this.customerService
        .apiCustomerCreateCustomerPost(createCustomer)
        .subscribe({
          next: (res) => {
            this.authService.currentUser.subscribe({
              next: (user) => {
                if (isEmpty(user.domainUserId)) {
                  this.authService.linkCustomer(res);
                }
              },
            });
          },
        });
    }
  }
}
