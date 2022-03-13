import { Component } from '@angular/core';

@Component({
    selector: 'app-office-status',
  templateUrl: './office-status.component.html',
  styleUrls: ['../../all-css.component.css']
})
/** OfficeStatus component*/
export class OfficeStatusComponent {

  officeStatus = ThisOfficeStatus;
    
    /** OfficeStatus ctor */
    constructor() {

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
