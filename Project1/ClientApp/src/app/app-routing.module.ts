import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfficeStatusComponent } from './Components/office-status/office-status.component';
import { UserStatusComponent } from './Components/user-status/user-status.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from '@auth0/auth0-angular';
import { AllUsersComponent } from './Components/all-users/all-users.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  //  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: "user-status", component: UserStatusComponent },
  { path: "office-status", component: OfficeStatusComponent },
  { path: "all-users", component: AllUsersComponent },
  { path: "user-profile", component: UserProfileComponent },
  { path: "login", component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
