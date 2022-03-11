import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-user-status',
    templateUrl: './user-status.component.html',
    styleUrls: ['./user-status.component.css']
})
/** UserStatus component*/
export class UserStatusComponent implements OnInit {
  
  userStatusList = UserStatusList;
  selectedUser?: UserStatus;

  /** UserStatus ctor */
  constructor() { }

  ngOnInit(): void {
    console.log(UserStatusList);
  }

  onSelect(user: UserStatus): void {
    this.selectedUser = user;
  }

 

}
interface UserStatus {
  Name: string;
  Surname: string;
  BuildingName: string;
  Office: string;
  RemoteStatus: string;
}


export const UserStatusList: UserStatus[] = [
  { Name: 'abc', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'def', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'ghi', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'jkl', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'mno', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'pqr', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'stu', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'vwx', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'yza', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'bcd', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'efg', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
  { Name: 'hij', Surname: 'Dr Nice', BuildingName: 'acasa', Office: '3', RemoteStatus: '30%' },
];
