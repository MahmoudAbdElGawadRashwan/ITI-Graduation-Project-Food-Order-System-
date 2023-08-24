import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { CartComponent } from './cart/cart.component';
import { ButtonModule } from 'primeng/button';
import { BadgeModule } from 'primeng/badge';
import { DialogModule } from 'primeng/dialog';
import { RatingModule } from 'primeng/rating';
import { DataViewModule } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, CartComponent],
  imports: [
    CommonModule,
    ButtonModule,
    BadgeModule,
    DialogModule,
    RatingModule,
    FormsModule,
    DataViewModule,
    TagModule,
    RouterModule,
  ],
  exports: [HeaderComponent, FooterComponent, CartComponent],
})
export class SharedModule {}
