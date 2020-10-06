import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { RouterModule } from '@angular/router';
import { environment } from '.././environments/environment';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RequestsComponent } from './requests/requests.component';
import { ActionsComponent } from './actions-list/actions/actions.component';
import { appRoutes } from './routes';
import { LogService } from './_services/log.service';
import { LoggerModule } from 'ngx-logger';
import { ActionsCardComponent } from './actions-list/actions-card/actions-card.component';
import { DaysEditComponent } from './actions-list/days-edit/days-edit.component';



@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      RequestsComponent,
      ActionsComponent,
      ActionsCardComponent,
      DaysEditComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService ,
      LogService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
