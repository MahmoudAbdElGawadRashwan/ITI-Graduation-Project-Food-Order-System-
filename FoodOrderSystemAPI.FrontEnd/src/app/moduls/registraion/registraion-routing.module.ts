import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { StepsModule } from 'primeng/steps';
import { ToastModule } from 'primeng/toast';

import { RouterModule, Routes } from '@angular/router';
import { RegisterAsCutomerComponent } from '../../Registraion/register-as-cutomer/register-as-cutomer.component';
import { RegisterAsResturantComponent } from '../../Registraion/register-as-resturant/register-as-resturant.component';
import { PaymentRegistrationComponent } from '../../Registraion/payment-registration/payment-registration.component';



const router: Routes = [ // End Points Coponents For Auth End Point
  
  {path: 'registerascustomer' , component : RegisterAsCutomerComponent},
  {path: 'registerasresturant' , component : RegisterAsResturantComponent},
  {path: 'paymentregistraion' , component : PaymentRegistrationComponent},
]
@NgModule({
  imports: [RouterModule.forChild(router)],
  exports:[
      RouterModule,
      ReactiveFormsModule,  // To Use FormsControls  And Form Groups in Authentcation Components !!
      FormsModule ,// To Use Ng model 2 way Binding 
      StepsModule,
      ToastModule
      
  ]
})
export class RegistraionRoutingModule { }




