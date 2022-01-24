import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import { EditCustomer, CustomerService, CustomerDto, AddressService, ContactInfoService, AddressDto, ContactInfoDto } from 'src/api';
import { AuthService } from '../auth.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {
  
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    dateOfBirth: new FormControl('', [Validators.required, this.dateValidator.bind(this)]),
    country: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    street: new FormControl('', Validators.required),
    streetNumber: new FormControl('', Validators.required),
    postCode: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', Validators.required),
  });

  customer: Observable<CustomerDto> | null = null;
  address: Observable<AddressDto> | null = null;
  contactInfo: Observable<ContactInfoDto> | null = null;
  customerId: string = "";
  minDate : number = new Date().getFullYear() - 18;
  submitted : boolean = false; 

  constructor(
    private readonly customerService: CustomerService,
    private readonly addressService: AddressService,
    private readonly contactInfoService: ContactInfoService,
    private readonly route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.customerId = <string>this.route.snapshot.paramMap.get('customerId')?.toString();
    this.fetchCustomer();
  }

  submit(): void {
    this.submitted = true;
    var editCustomer: EditCustomer = this.form.value;
    if (this.form.valid) {
      this.customerService
        .apiCustomerEditCustomerIdPut(this.customerId, editCustomer)
        .subscribe({
          next: (res) => {
            this.router.navigate(['/', 'customers']);
          },
        });
    }
  }

  private fetchCustomer(): void {
    this.customer = this.customerService.apiCustomerGetCustomerByIdIdGet(
      this.customerId, 
    )

    this.customer.subscribe(
      res => {

        this.form.patchValue({firstName: res.firstName});
        this.form.patchValue({lastName: res.lastName});
        this.form.patchValue({dateOfBirth: formatDate(<string>res.dateOfBirth, "YYYY-MM-dd", "en-US")});
        console.log(formatDate(<string>res.dateOfBirth, "YYYY-MM-dd", "en-US"))

        this.address = this.addressService.apiAddressGetAddressByIdIdGet(
          <string>res.addresses![0].id?.toString(),
        )

        this.address.subscribe(
          res => {
            this.form.patchValue({country: res.country});
            this.form.patchValue({city: res.city});
            this.form.patchValue({street: res.street});
            this.form.patchValue({streetNumber: res.streetNumber});
            this.form.patchValue({postCode: res.postCode});
          }
        )

        this.contactInfo = this.contactInfoService.apiContactInfoGetContactInfoByIdIdGet(
          <string>res.contactInfos![0].id?.toString(),
        )

        this.contactInfo?.subscribe(
          res => {
            this.form.patchValue({email: res.email});
            this.form.patchValue({phoneNumber: res.phoneNumber});
          }
        )

      }
    )
  }

  get f(): { [key: string]: AbstractControl; }
  {
    return this.form.controls;
  }

  dateValidator(control: FormControl): { [s: string]: boolean } | null {
    if (control.value) {
      const date = new Date(this.form.controls['dateOfBirth'].value);
      const dateYr = date.getFullYear();
      const minDate = this.minDate;
      
      if (minDate<=dateYr) {
        return { 'invalidDate': true }
      }
    }
    return null;
  }
}
