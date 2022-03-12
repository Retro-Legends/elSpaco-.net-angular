import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserStatusComponent } from './Components/user-status/user-status.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  //  { path: 'login', component: LoginComponent },
  //  { path: 'register', component: RegisterComponent },
  {
    path: "admin", loadChildren: () => import("../app/Components/admin-section.module").then(m => m.AdminSectionModule)
  },
  {
    path: "user", loadChildren: () => import("../app/Components/user-section.module").then(m => m.UserSectionModule)
  },
  { path: "user-status", component: UserStatusComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
