import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-office-status',
  templateUrl: './office-status.component.html',
  styleUrls: ['../../all-css.component.css']
})
/** OfficeStatus component*/
export class OfficeStatusComponent {

  officeStatus: OfficeStatus;

  /** OfficeStatus ctor */
  constructor(http: HttpClient, public auth: AuthService, @Inject('BASE_URL') baseUrl: string) {

    http.get<OfficeStatus>(baseUrl + getUserId()).subscribe(result => {
      this.officeStatus = result;
    }, error => console.error(error));
  }
}


interface OfficeStatus {
  officeName: string;
  buildingName: string;
  users: string[];
  ocupiedDeskCount: number;
  usableDeskCount: number;
  freeDeskCount: number;
  ocupationPercentage: number;
}

function getUserId() {
  return "alluser/1";
  //SchimbaAici
}


