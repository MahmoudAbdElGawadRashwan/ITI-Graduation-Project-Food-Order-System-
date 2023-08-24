import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddProductComponent } from './add-product.component';
import { ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    AddProductComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
})
export class AddProductModule { }
