import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
    selector: 'app-office-status',
  templateUrl: './office-status.component.html',
  styleUrls: ['../../all-css.component.css']
})
/** OfficeStatus component*/
export class OfficeStatusComponent {

  officeStatus = ThisOfficeStatus;
    
    /** OfficeStatus ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserStatus[]>(baseUrl + 'alluser/').subscribe(result => {
      this.userStatus = result;
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

export const ThisOfficeStatus: OfficeStatus = {
  OfficeName : "3",
  BuildingName : "cafenea",
  Users : "bogan , Marcel",
  OcupiedDeskCount : 2,
  UsableDeskCount : 4,
  FreeDeskCount : 2,
  OcupationPercentage : 50
}
