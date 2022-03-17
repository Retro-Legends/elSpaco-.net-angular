import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
    selector: 'app-user-status',
  templateUrl: './user-status.component.html',
  styleUrls: ['../../all-css.component.css']
})
/** UserStatus component*/
export class UserStatusComponent implements OnInit {

  public userStatus: UserStatus[];
  selectedUser?: UserStatus;
  public filtredUserList: UserStatus[];
  public pagesize: 10;

  /** UserStatus ctor */
  constructor(http: HttpClient, public auth: AuthService, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserStatus[]>(baseUrl + 'alluser/').subscribe(result => {
      this.userStatus = result;
    }, error => console.error(error));
  }

  ngOnInit(): void { }

  
  onSelect(user: UserStatus): void {
    if (this.selectedUser == null)
      this.selectedUser = user;
    else
      this.selectedUser = undefined;
  }
  fliter(users: UserStatus): void {
    //someLogicHere
    this.filtredUserList = this.userStatus;
  }
}


interface UserStatus {
  id: number;
  name: string;
  surname: string;
  buildingName: string;
  office: string;
  remoteStatus: string;
  role: string;
  birthDate: string;
  gender: string;
  nationality: string;
}

