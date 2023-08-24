import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { StepsModule } from 'primeng/steps';
import { ToastModule } from 'primeng/toast';

import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../../Authentcation/login/login.component';

const router: Routes = [ // End Points Coponents For Auth End Point
  { path: 'login', component: LoginComponent },
]


@NgModule({
  declarations: [],
  imports: [
  CommonModule,
  RouterModule.forChild(router) // Access Child Coponents For Authentcation End Point Route
  ],
  exports:
    [
      RouterModule,
      ReactiveFormsModule,  // To Use FormsControls  And Form Groups in Authentcation Components !!
      FormsModule ,// To Use Ng model 2 way Binding 
      StepsModule,
      ToastModule
      
  ]
})
export class AuthentcationRoutingModule {}
