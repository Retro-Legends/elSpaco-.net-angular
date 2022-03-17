import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfficeStatusComponent } from './Components/office-status/office-status.component';
import { UserStatusComponent } from './Components/user-status/user-status.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from '@auth0/auth0-angular';


const routes: Routes = [
  //  { path: 'login', component: LoginComponent },
  { path: 'office-status', component: OfficeStatusComponent, canActivate: [AuthGuard], },
  { path: "user-status", component: UserStatusComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
