import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
// import { CustomersComponent } from './customers/customers.component';
import { HomePageComponent } from './home-page/home-page.component';

import { InputTextModule } from 'primeng/inputtext';
import { CarouselModule } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { PanelModule } from 'primeng/panel';
import { CheckboxModule } from 'primeng/checkbox';
import { SliderModule } from 'primeng/slider';
import { CardModule } from 'primeng/card';
import { RatingModule } from 'primeng/rating';
import { ImageModule } from 'primeng/image';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeFilterComponent } from './home-filter/home-filter.component';
import { HomeCardComponent } from './home-card/home-card.component';
import { FormsModule } from '@angular/forms';
import { HomeRestaurantsComponent } from './home-restaurants/home-restaurants.component';

@NgModule({
  declarations: [
    HomePageComponent,
    HomeFilterComponent,
    HomeCardComponent,
    HomeRestaurantsComponent,
  ],
  imports: [
    CommonModule
    ,BrowserModule
    ,BrowserAnimationsModule
    ,InputTextModule,CarouselModule,TagModule,ButtonModule,PanelModule,CheckboxModule,SliderModule,CardModule,RatingModule
    ,FormsModule
    , RouterModule
    , ImageModule
  ],
  exports:[
    HomePageComponent
  ]
})
export class HomeModule { }
