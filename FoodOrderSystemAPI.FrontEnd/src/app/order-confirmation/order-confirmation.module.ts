import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderCondirmationComponent } from './order-condirmation/order-condirmation.component';
import { ButtonModule } from 'primeng/button';



@NgModule({
  declarations: [
    OrderCondirmationComponent
  ],
  imports: [
    CommonModule
    , ButtonModule
  ]
})
export class OrderConfirmationModule { }
