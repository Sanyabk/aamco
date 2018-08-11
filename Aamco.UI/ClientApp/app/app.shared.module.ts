import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule } from '@angular/material';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ScheduleAppointmentComponent } from './components/schedule-appointment/schedule-appointment.component';
import { NewAppointmentComponent } from './components/new-appointment/new-appointment.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { SocialShareComponent } from './components/social-share/social-share.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { SocialContactsComponent } from './components/social-contacts/social-contacts.component';
import { LogoComponent } from './components/common/logo/logo.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        HeaderComponent,
        FooterComponent,
        NavbarComponent,
        ScheduleAppointmentComponent,
        NewAppointmentComponent,
        SignUpComponent,
        SocialShareComponent,
        CategoriesComponent,
        SocialContactsComponent,
        LogoComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
