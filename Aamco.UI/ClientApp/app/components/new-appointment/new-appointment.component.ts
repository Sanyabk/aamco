import { Component, OnInit } from '@angular/core';

interface DateTime {
  date: string;
  time: {
    hour: number,
    minute: number
  };
}

@Component({
  selector: 'app-new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.css']
})
export class NewAppointmentComponent implements OnInit {

  services: Array<any> = [
    { id: 1, name: 'Transmission' },
    { id: 2, name: 'Vehicle Maintenance' },
    { id: 3, name: 'Vehicle Repair' },
    { id: 4, name: 'Other' },
  ];

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
    name: string
  };

  personalInfo: {
    firstName: string,
    lastName: string,
    email: string,
    phone: string,
  };

  constructor() {
    this.resetForm();
  }

  ngOnInit() {
  }

  makeAppointment() {
    console.log(this);
  }

  resetForm() {
    const now = new Date();
    const tomorrow = new Date();
    tomorrow.setDate(now.getDate() + 1);

    this.start ={
      date: now.toISOString(),
      time: {
        hour: 8, minute: 0
      }
    };
    this.end = {
      date: tomorrow.toISOString(),
      time: {
        hour: 8, minute: 0
      }
    };
    this.services.forEach(s => s.checked = false); //fill checked property for every service
    this.vehicle = { year: undefined, name: '' };
    this.personalInfo = { firstName: '', lastName: '', email: '', phone: '' };
  }
}
