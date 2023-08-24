import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { CustomersComponent } from 'src/app/home/customers/customers.component';

const routes: Routes = [
  // { path:'customers' , component: CustomersComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
