import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface DateTime {
  date: string;
  time: {
    hour: number,
    minute: number
  };
}

interface VehicleService {
  id: number;
  name: string;
}

interface VehicleMark {
  id: number;
  name: string;
}

@Component({
  selector: 'app-new-appointment',
  templateUrl: './new-appointment.component.html',
  styleUrls: ['./new-appointment.component.css']
})
export class NewAppointmentComponent implements OnInit {

  API_BASE_URL: string = 'http://localhost:50950';

  services: Array<any> = [
    { id: 1, name: 'Transmission' },
    { id: 2, name: 'Vehicle Maintenance' },
    { id: 3, name: 'Vehicle Repair' },
    { id: 4, name: 'Other' },
  ];
  
  marks: Array<any>;

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

  constructor(private http: HttpClient) {
    
    this.resetForm();

    http.get<Array<VehicleMark>>(`${this.API_BASE_URL}/api/vehiclemark`)
      .subscribe(marks => this.marks = marks);

    http.get<Array<VehicleService>>(`${this.API_BASE_URL}/api/vehicleservice`)
      .subscribe(services => this.services = services);
      
  }

  ngOnInit() {
  }

  makeAppointment() {
    const appointment = {};
    this.http.post(`${this.API_BASE_URL}/api/appointment`, appointment)
      .subscribe(result => {

      })
  }

  resetForm() {
    const now = new Date();
    const tomorrow = new Date();
    tomorrow.setDate(now.getDate() + 1);

    this.start = {
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
