import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthentcationRoutingModule } from './authentcation-routing.module';
import { LoginComponent } from '../../Authentcation/login/login.component';
// import { PersonlDataComponent } from '../../Authentcation/Register/personl-data/personl-data.component';



@NgModule({
  declarations: [LoginComponent ],
  imports: [CommonModule, AuthentcationRoutingModule ],
})
export class AuthentcationModule {}
