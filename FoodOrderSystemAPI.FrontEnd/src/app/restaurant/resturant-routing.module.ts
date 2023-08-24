import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { ResturantOrdersComponent } from './resturant-orders/resturant-orders.component';

const Router: Routes = [
  { path: 'Orders', component: ResturantOrdersComponent },
];

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [],
})
export class ResturantRoutingModule {}
