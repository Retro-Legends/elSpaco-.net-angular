import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
    selector: 'app-user-profile',
    templateUrl: './user-profile.component.html',
    styleUrls: ['./user-profile.component.css']
})
/** UserProfile component*/
export class UserProfileComponent {
    /** UserProfile ctor */
  constructor(public auth: AuthService) {

    }
}
