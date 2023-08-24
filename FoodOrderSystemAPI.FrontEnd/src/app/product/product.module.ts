import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { RatingModule } from 'primeng/rating';
import { PaginatorModule } from 'primeng/paginator';
import { SelectButtonModule } from 'primeng/selectbutton';

import { ProductDetailsComponent } from './product-details/product-details.component';

import {} from 'primeng/';
import { ProductUpdateComponent } from './product-update/product-update.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ProductDetailsComponent, ProductUpdateComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    TableModule,
    ButtonModule,
    RatingModule,
    FormsModule,
    PaginatorModule,
    SelectButtonModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  exports: [ProductDetailsComponent],
})
export class ProductModule {}
