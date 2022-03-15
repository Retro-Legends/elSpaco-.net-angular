import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { AppUserAuth } from '../auth.model';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['../all-css.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isAuthenticated: boolean;

  constructor(public auth: AuthService,
    @Inject(DOCUMENT) private doc: Document) {

  }
  public ngOnInit(): void {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  async loginWithRedirect() {
    
    this.auth.loginWithRedirect();
    this.auth.isAuthenticated$.subscribe(
      (success: boolean) => {
        this.isAuthenticated = true;
      },
      error => this.isAuthenticated = false);
  }

  logout() {
    this.auth.logout({ returnTo: this.doc.location.origin });
    this.auth.isAuthenticated$.subscribe(
      (success: boolean) => {
        this.isAuthenticated = true;
      },
      error => this.isAuthenticated = false);
  }

}
