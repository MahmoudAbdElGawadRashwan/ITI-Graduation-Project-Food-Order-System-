import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistraionRoutingModule } from './registraion-routing.module';
import { RegisterAsCutomerComponent } from '../../Registraion/register-as-cutomer/register-as-cutomer.component';
import { RegisterAsResturantComponent } from '../../Registraion/register-as-resturant/register-as-resturant.component';
import { PaymentRegistrationComponent } from '../../Registraion/payment-registration/payment-registration.component';


@NgModule({
  declarations: [RegisterAsCutomerComponent, RegisterAsResturantComponent , PaymentRegistrationComponent ],
  imports: [
    CommonModule,
    RegistraionRoutingModule
  ]
})
export class RegistraionModule { }
