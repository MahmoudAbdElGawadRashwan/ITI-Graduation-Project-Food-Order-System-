import { Component, DoCheck, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { CustomerProfileDetails } from 'src/app/types/Customer/customer-profile-details-dto';

@Component({
  selector: 'app-customer-profile-details',
  templateUrl: './customer-profile-details.component.html',
  styleUrls: ['./customer-profile-details.component.css'],
})
export class CustomerProfileDetailsComponent implements OnInit {
  _customer: CustomerProfileDetails = new CustomerProfileDetails();
  constructor(
    private activatedRoute: ActivatedRoute,
    private customerService: CustomerService
  ) {}
  ngOnInit(): void {
    this.getCustomer();
  }
  getCustomer() {
    let urlCustomerId = this.activatedRoute.snapshot.paramMap.get('id');
    if (urlCustomerId) {
      let customerId = parseInt(urlCustomerId);
      this.customerService.getCustomer(customerId).subscribe(
        (data) => {
          this._customer = data;
        },
        (error) => {
          console.log(`error: ${error}`);
        }
      );
    }
  }
}
