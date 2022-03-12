import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
    selector: 'app-user-status',
    templateUrl: './user-status.component.html',
    styleUrls: ['./user-status.component.css']
})
/** UserStatus component*/
export class UserStatusComponent implements OnInit {

  public userStatus: UserStatus[];
  selectedUser?: UserStatus;

  /** UserStatus ctor */
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserStatus[]>(baseUrl + 'alluser/').subscribe(result => {
      this.userStatus = result;
      console.log(result);
    }, error => console.error(error));
    console.log(baseUrl);
  }

  ngOnInit(): void {}

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

