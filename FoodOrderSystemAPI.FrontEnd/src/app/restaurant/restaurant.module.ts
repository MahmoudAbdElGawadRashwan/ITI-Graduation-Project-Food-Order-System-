import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { RestCardComponent } from './rest-card/rest-card.component';
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
import { RestaurantPageComponent } from './restaurant-page/restaurant-page.component';
import { RestaurantFilterComponent } from './restaurant-filter/restaurant-filter.component';
import { FormsModule } from '@angular/forms';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { ResturantOrdersComponent } from './resturant-orders/resturant-orders.component';
import { ResturantRoutingModule } from './resturant-routing.module';
import { RestaurantUpdateComponent } from './restaurant-update/restaurant-update.component';

const Router: Routes = [
  { path: 'Orders', component: ResturantOrdersComponent },
];
@NgModule({
  declarations: [
    RestCardComponent,
    RestaurantPageComponent,
    RestaurantFilterComponent,
    RestaurantDetailsComponent,
    ResturantOrdersComponent,
    RestaurantUpdateComponent,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    InputTextModule,
    CarouselModule,
    TagModule,
    ButtonModule,
    PanelModule,
    CheckboxModule,
    SliderModule,
    CardModule,
    RatingModule,
    FormsModule,
    RouterModule,
    ImageModule,
    ReactiveFormsModule,
  ],
})
export class RestaurantModule {}
