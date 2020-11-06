import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BikeComponent } from './bike/bike.component';
import { LoginComponent } from './login/login.component';
import { BikeRentHistoryComponent } from './bike-rent-history/bike-rent-history.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { authInterceptorProviders } from '../app/helpers/authInterceptor';

@NgModule({
  declarations: [
    AppComponent,    
    BikeComponent,
    LoginComponent,
    BikeRentHistoryComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'bike', component: BikeComponent },
      { path: 'bikeRent', component: BikeRentHistoryComponent },
    ])
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
