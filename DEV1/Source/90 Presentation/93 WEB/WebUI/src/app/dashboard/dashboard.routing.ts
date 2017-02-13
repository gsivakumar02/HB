import { Routes } from "@angular/router";

import { DashboardComponent } from './dashboard.component';
import { AuthGuard } from '../_guards/index';

export const DashboardRoutes: Routes = [{
  path: '',
  component: DashboardComponent,  canActivate: [AuthGuard]
}];