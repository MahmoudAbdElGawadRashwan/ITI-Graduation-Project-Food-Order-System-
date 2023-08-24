import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NotFoundComponent } from './error/not-found/not-found.component';
import { HomePageComponent } from './home/home-page/home-page.component';
import { RestaurantPageComponent } from './restaurant/restaurant-page/restaurant-page.component';
import { ProductDetailsComponent } from './product/product-details/product-details.component';
import { CustomerProfileDetailsComponent } from './customer/customer-profile-details/customer-profile-details.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AddProductComponent } from './add-product/add-product.component';
import { AddCardComponent } from './AddCard/add-card.component';
import { NavigationRegisterComponent } from './Registraion/navigation-register/navigation-register.component';
import { ResturantOrdersComponent } from './restaurant/resturant-orders/resturant-orders.component';

import { OrderCondirmationComponent } from './order-confirmation/order-condirmation/order-condirmation.component';

import { RestaurantUpdateComponent } from './restaurant/restaurant-update/restaurant-update.component';
import { ProductUpdateComponent } from './product/product-update/product-update.component';



const Router: Routes = [
  // (Lazy Loading ) Laod Module Only when Access authentiction in Url !!
  {
    path: 'authentcation',
    loadChildren: () =>
      import('./moduls/Authentcation/authentcation.module').then(
        (m) => m.AuthentcationModule
      ),
  },
  { path: 'registration', component: NavigationRegisterComponent },
  {
    path: 'registration',
    loadChildren: () =>
      import('./moduls/registraion/registraion.module').then(
        (m) => m.RegistraionModule
      ),
  },
  { path: 'home', component: HomePageComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'addproduct', component: AddProductComponent },
  { path: 'productUpdate/:Id', component: ProductUpdateComponent },
  { path: 'addcard', component: AddCardComponent },
  { path: 'ResturantOrders', component: ResturantOrdersComponent },
  { path: 'restaurant/:id', component: RestaurantPageComponent },
  { path: 'restaurantUpdate', component: RestaurantUpdateComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'customer/:id', component: CustomerProfileDetailsComponent },
  { path: 'orderconfirmation', component: OrderCondirmationComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule, // To Use Pipes And Directives & Commmon Features in app Orgnization Wise
    RouterModule.forRoot(Router),
  ],
  exports: [
    HttpClientModule, // Import Module For Help Any Server Requsts
    RouterModule,
  ],
})
export class AppRoutingModule {}
