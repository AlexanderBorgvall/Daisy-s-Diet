// AppRoutingModule
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FrontPageComponent } from './frontpage/frontpage.component';
import { LoginComponent } from './login/login.component';
import { EmployeeComponent } from './employee/employee.component';

//import { ManagerComponent } from './manager/manager.component';

export const routes: Routes = [
  { path: '', redirectTo: '/frontpage', pathMatch: 'full' },
  { path: 'frontpage', component: FrontPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'employees', component: EmployeeComponent },
  //{ path: 'manager', component: ManagerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
