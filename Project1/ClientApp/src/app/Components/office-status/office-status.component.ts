import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
    selector: 'app-office-status',
  templateUrl: './office-status.component.html',
  styleUrls: ['../../all-css.component.css']
})
/** OfficeStatus component*/
export class OfficeStatusComponent {

  officeStatus: OfficeStatus;
    
    /** OfficeStatus ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<OfficeStatus>(baseUrl + getUserId()).subscribe(result => { 
      this.officeStatus = result;
    }, error => console.error(error));
  }
}

interface OfficeStatus {
  OfficeName: string;
  BuildingName: string;
  Users: string;
  OcupiedDeskCount: number;
  UsableDeskCount: number;
  FreeDeskCount: number;
  OcupationPercentage: number;
}

function getUserId() {
  return "alluser/1";
  //SchimbaAici
}
