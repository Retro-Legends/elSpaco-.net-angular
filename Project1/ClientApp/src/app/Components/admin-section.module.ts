import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { AdminSectionComponent } from './admin-section/admin-section.component';
import { AdminSectionRoutingModule } from "./admin-section-routing.module";

@NgModule({
  declarations: [AdminSectionComponent],
  imports: [CommonModule, AdminSectionRoutingModule]
})
export class AdminSectionModule { }
