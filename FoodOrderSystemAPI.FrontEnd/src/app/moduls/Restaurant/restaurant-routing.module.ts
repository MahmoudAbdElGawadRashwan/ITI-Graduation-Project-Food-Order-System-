import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResturantOrdersComponent } from 'src/app/restaurant/resturant-orders/resturant-orders.component';

const routes: Routes = [
    {path:'ResturantOrders' , component:ResturantOrdersComponent}
];

@NgModule({
imports: [RouterModule.forChild(routes)],
exports: [RouterModule]
})
export class RestaurantRoutingModule { }