import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./all-css.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(public auth: AuthService) { }
}
