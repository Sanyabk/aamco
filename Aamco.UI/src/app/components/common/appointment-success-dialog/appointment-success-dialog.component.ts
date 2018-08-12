import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppointmentDetails } from '../appointment-details';

//may be used for passing additional data to dialog
interface AppointmentSuccessDialogData {
  details: AppointmentDetails;
}

@Component({
  selector: 'appointment-success-dialog',
  templateUrl: 'appointment-success-dialog.component.html',
  styleUrls: ['./appointment-success-dialog.component.css']
})
export class AppointmentSuccessDialogComponent {
  details: AppointmentDetails;
  dateFormat: string = 'dd MMM yyyy, hh:mm a';
  
  constructor(public dialogRef: MatDialogRef<AppointmentSuccessDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: AppointmentSuccessDialogData) {
    this.details = data.details;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
