import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material';
import { AppointmentSuccessDialogComponent } from '../common/appointment-success-dialog/appointment-success-dialog.component';
import { AppointmentDetails } from '../common/appointment-details';

interface DateTime {
  date: Date;
  time: {
    hour: number,
    minute: number
  };
}

interface VehicleService {
  id: number;
  name: string;
  checked?: boolean;
}

interface VehicleMark {
  id: number;
  name: string;
}

interface Appointment {
  id?: number,

  startsOn: Date,
  endsOn: Date,

  firstName: string,
  secondName: string,
  email: string,
  phone: string,

  vehicleMarkId: number,
  vehicleYear: number,
  vehicleServicesIds: Array<number>,
}; 

@Component({
  selector: 'app-new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.css']
})
export class NewAppointmentComponent implements OnInit {

  API_BASE_URL: string = 'http://localhost:50950';

  services: Array<VehicleService>;
  marks: Array<VehicleMark>;
  today: Date = new Date();
  storeHours: Array<any> = [
    { id: 1, days: 'MON - WED', hours: '08:00 AM - 05:00 PM' },
    { id: 2, days: 'THU', hours: '08:00 AM - 04:00 PM' },
    { id: 3, days: 'FRI', hours: '08:00 AM - 01:00 PM' },
    { id: 4, days: 'SAT', hours: 'CLOSE' },
  ];

  start: DateTime;
  end: DateTime;

  vehicle: {
    year: number,
    markId: number,
  };

  personalInfo: {
    firstName: string,
    secondName: string,
    email: string,
    phone: string,
  };

  constructor(private http: HttpClient, private dialog: MatDialog) {

    //fill form with default values
    this.resetForm();

    http.get<Array<VehicleMark>>(`${this.API_BASE_URL}/api/vehiclemark`)
      .subscribe(marks => this.marks = marks);

    http.get<Array<VehicleService>>(`${this.API_BASE_URL}/api/vehicleservice`)
      .subscribe(services => {
        this.services = services;
        this.services.forEach(s => s.checked = false); //fill checked property for every service
      });

  }

  ngOnInit() {
  }

  convertDateTime(input: DateTime): Date {
    //clone input
    const date = new Date(input.date.getTime());

    //fill with time
    date.setHours(input.time.hour);
    date.setMinutes(input.time.minute);
    date.setSeconds(0); //for consistency

    return date;
  }

  makeAppointment() {

    const startsOn = this.convertDateTime(this.start);
    const endsOn = this.convertDateTime(this.end);
    const vehicleServicesIds = this.services.filter(s => s.checked).map(s => s.id);

    const appointment : Appointment = {
      startsOn: startsOn,
      endsOn: endsOn,

      firstName: this.personalInfo.firstName,
      secondName: this.personalInfo.secondName,
      email: this.personalInfo.email,
      phone: this.personalInfo.phone,

      vehicleMarkId: this.vehicle.markId,
      vehicleYear: this.vehicle.year,
      vehicleServicesIds: vehicleServicesIds,
    };
    console.log(this, appointment);
    this.http.post<AppointmentDetails>(`${this.API_BASE_URL}/api/appointment`, appointment)
      .subscribe(details => {
        //open success appointment dialog
        const dialogRef = this.dialog.open(AppointmentSuccessDialogComponent, {
          width: '450px',
          data: { details }
        });

        //reset form after success dialog is closed
        dialogRef.afterClosed().subscribe(result => {
          this.resetForm();
        });
     }, this.handleError);
  }
  handleError(error) {
    console.log(error);
  }
  resetForm() {
    const now = new Date();
    const tomorrow = new Date();
    tomorrow.setDate(now.getDate() + 1);

    this.start = {
      date: now,//.toISOString(),
      time: {
        hour: 8, minute: 0
      }
    };
    this.end = {
      date: tomorrow,//.toISOString(),
      time: {
        hour: 8, minute: 0
      }
    };

    //fill checked property for every service
    if (this.services) this.services.forEach(s => s.checked = false);

    this.vehicle = { year: undefined, markId: undefined };
    this.personalInfo = { firstName: '', secondName: '', email: '', phone: '' };
  }
}
