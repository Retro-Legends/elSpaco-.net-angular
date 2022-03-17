import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { UserStatusComponent } from './Components/user-status/user-status.component';
import { OfficeStatusComponent } from './Components/office-status/office-status.component';
import { AllUsersComponent } from './Components/all-users/all-users.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { AuthModule } from '@auth0/auth0-angular';
import { environment as env } from '../environments/environment';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { enableProdMode } from '@angular/core';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserStatusComponent,
    OfficeStatusComponent,
    AllUsersComponent,
    UserProfileComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: "user-status", component: UserStatusComponent },
      { path: "office-status", component: OfficeStatusComponent },
      { path: "all-users", component: AllUsersComponent },
      { path: "user-profile", component: UserProfileComponent }

    ]),
    NgxPaginationModule,
    BrowserAnimationsModule,
    AuthModule.forRoot({
      "domain": "dev-c181lrmf.eu.auth0.com",
      "clientId": "ZWko5ZkNXSEs2O6DDJ4Hydn0gpywu7uG"
    }),
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
