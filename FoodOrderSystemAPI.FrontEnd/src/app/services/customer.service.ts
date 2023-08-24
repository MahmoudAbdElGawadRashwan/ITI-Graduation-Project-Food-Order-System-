import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs';
import { CustomerProfileDetails } from '../types/Customer/customer-profile-details-dto';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private configService: ConfigService, private http: HttpClient) {}

  getCustomer(customerId: number): Observable<CustomerProfileDetails> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<CustomerProfileDetails>(
      `${baseUrl}/customer/${customerId}`
    );
  }
}
