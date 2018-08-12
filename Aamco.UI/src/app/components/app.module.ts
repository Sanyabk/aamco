import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatSelectModule, MatDialogModule } from '@angular/material';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ScheduleAppointmentComponent } from './schedule-appointment/schedule-appointment.component';
import { NewAppointmentComponent } from './new-appointment/new-appointment.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { SocialShareComponent } from './social-share/social-share.component';
import { CategoriesComponent } from './categories/categories.component';
import { SocialContactsComponent } from './social-contacts/social-contacts.component';
import { LogoComponent } from './common/logo/logo.component';
import { AppointmentSuccessDialogComponent } from './common/appointment-success-dialog/appointment-success-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavbarComponent,
    ScheduleAppointmentComponent,
    NewAppointmentComponent,
    SignUpComponent,
    SocialShareComponent,
    CategoriesComponent,
    SocialContactsComponent,
    LogoComponent,
    AppointmentSuccessDialogComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatDialogModule,
    NgbModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    AppointmentSuccessDialogComponent,
  ]
})
export class AppModule { }
