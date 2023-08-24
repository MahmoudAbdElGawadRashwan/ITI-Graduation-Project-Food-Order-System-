import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AddCardComponent } from './add-card.component';


@NgModule({
  declarations: [
    AddCardComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,

  ],
  exports: [
    AddCardComponent
  ]
})
export class AddCardModule { }
