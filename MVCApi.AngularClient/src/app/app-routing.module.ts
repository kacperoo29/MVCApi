import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories/categories.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CustomersComponent } from './customers/customers.component';

const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  { path: 'customers/add', component: CustomerFormComponent },
  { path: 'categories', component: CategoriesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
