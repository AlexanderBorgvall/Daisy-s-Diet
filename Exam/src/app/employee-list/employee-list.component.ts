// EmployeeListComponent
import { Component, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';
import { Router } from '@angular/router';
import { EmployeeComponent } from "../employee/employee.component";

@Component({
    selector: 'app-employee-list',
    standalone: true,
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css'],
    imports: [EmployeeComponent]
})
export class EmployeeListComponent implements OnInit {
  employeeList: Employee[] = [];

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    if (this.employeeService.authHeader == null) {
    this.router.navigate(["login"]);
    return;
    }
    this.employeeService.getEmployees().subscribe((employees) => {
    this.employeeList = employees;
    });
    }
  }