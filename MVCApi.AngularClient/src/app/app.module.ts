import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryTreeComponent } from './category-tree/category-tree.component';
import { CategoriesComponent } from './categories/categories.component';
import { ProductsComponent } from './products/products.component';
import { ProductComponent } from './product/product.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { BASE_PATH, Configuration, UserService } from 'src/api';
import { SignOutComponent } from './sign-out/sign-out.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { registerLocaleData } from '@angular/common';

import(
  /* webpackExclude: /\.d\.ts$/ */
  /* webpackMode: "lazy-once" */
  /* webpackChunkName: "i18n-extra" */
  `@/../@angular/common/locales/${navigator.language}.mjs`
).then(locale => { registerLocaleData(locale.default); });

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    CustomerFormComponent,
    CategoryTreeComponent,
    CategoriesComponent,
    ProductsComponent,
    ProductComponent,
    SignInComponent,
    SignOutComponent,
    ShoppingCartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  providers: [
    { provide: BASE_PATH, useValue: 'http://localhost:5000' },
    {
      provide: UserService,
      useFactory: (httpClient: HttpClient) =>
        new UserService(
          httpClient,
          'http://localhost:5000',
          new Configuration({
            credentials: {
              Bearer: () => localStorage.getItem('jwt_token')!,
            },
          })
        ),
      deps: [HttpClient],
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
