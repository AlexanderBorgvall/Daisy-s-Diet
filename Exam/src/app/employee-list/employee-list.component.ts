import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Timeregistration } from '../model/timeregistration';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule],
})
export class EmployeeListComponent implements OnInit {
  @Input() timeregistration!: Timeregistration;
  TimeRegistrations: Timeregistration[] = [];
  Employeename: string = ""
  EmployeeId?: number = undefined

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    // Redirect to login page if not authenticated
    if (!this.employeeService.authHeader) {
      this.router.navigate(["login"]);
      return;
    }
  }
    
    // Fetch employee data if authenticated
    getTimeRegistrations (){
    this.employeeService.getTimeRegistrations(this.EmployeeId).subscribe((data) => {
      this.TimeRegistrations = data.registrations;
      this.TimeRegistrations = this.TimeRegistrations.map(reg => ({...reg, dateworked: new Date(reg.dateworked).toLocaleDateString()}))
      this.Employeename = data.employeeName
    });
  }
}
