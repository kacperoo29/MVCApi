import { Component, OnInit } from '@angular/core';
import { ApplicationUserDto, CustomerDto, CustomerService } from 'src/api';
import { isEmpty } from 'src/util';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  user: ApplicationUserDto | null = null;
  hasCustomer: boolean = false;
  customer: CustomerDto | null = null;

  constructor(
    private readonly authService: AuthService,
    private readonly customerService: CustomerService
  ) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe({
      next: (user) => {
        this.user = user;
        this.hasCustomer = !isEmpty(this.user.domainUserId);
        if (this.hasCustomer) {
          this.customerService
            .apiCustomerGetCustomerByIdIdGet(this.user.domainUserId!)
            .subscribe({
              next: (customer) => {
                this.customer = customer;
              },
              error: (err) => console.log(err),
            });
        }
      },
    });
  }
}
