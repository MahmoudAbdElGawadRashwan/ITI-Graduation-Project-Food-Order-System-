import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { CustomerToRegisterDto } from '../types/Customer/customer-to-register-dto';
import { ResturantRegister } from '../types/resturant-register';
import { TokenDto } from '../types/token-dto';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {

  // If The Customer Is Registers 
  RegisterdCustomer: CustomerToRegisterDto = new CustomerToRegisterDto();

  // If Resturant Is Registers 
  RegisterResturant: ResturantRegister = new ResturantRegister();

  constructor(private httpclient: HttpClient  , private  configservice :ConfigService) {}

  
  //Method To Customer Register
  Register(): Observable<TokenDto> {
    // Post requst to REgister End point That   Login the Registerd User and and Return TokenDto 
    const RegisterdCustomerTokenDto = this.httpclient.post<TokenDto>(
      `${this.configservice.getBaseApiUrl()}Customer`,
      this.RegisterdCustomer
    );
    return RegisterdCustomerTokenDto;
  }

    //Method To Customer Register

  RegisterAsResturant(): Observable<TokenDto> {
    // Post requst to REgister End point That   Login the Registerd User and and Return TokenDto 
    const RegisterdResturntTokenDto = this.httpclient.post<TokenDto>(
      `${this.configservice.getBaseApiUrl()}Restaurant`,
      this.RegisterResturant
    );
    return RegisterdResturntTokenDto;
  }


}
