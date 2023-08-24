// import { AgmCoreModule } from '@agm/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CheckoutModule } from './checkout/checkout.module';
import { AddProductModule } from './add-product/add-product.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { JwtTokenInterceptor } from './Interceptors/jwt-token.interceptor';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { SharedModule } from './shared/shared.module';
import { ErrorModule } from './error/error.module';
import { HomeModule } from './home/home.module';
import { RestaurantModule } from './restaurant/restaurant.module';
import { ProductModule } from './product/product.module';
import { NavigationRegisterComponent } from './Registraion/navigation-register/navigation-register.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderCondirmationComponent } from './order-confirmation/order-condirmation/order-condirmation.component';

@NgModule({
  declarations: [AppComponent, NavbarComponent, NavigationRegisterComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ErrorModule,
    HomeModule,
    HttpClientModule,
    RestaurantModule,
    BrowserAnimationsModule,
    SharedModule,
    CommonModule,
    NgbModule,
    CheckoutModule,
    AddProductModule,
    ProductModule,
    RouterModule,
    
    // AgmCoreModule.forRoot({
    //   apiKey: 'AIzaSyBPfbHdhiBn2prqXNfZKa0yFYVPOWMVvKU', // Replace with your actual API key
    // }),
    // GoogleMapsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtTokenInterceptor,
      multi: true,
    },
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}
