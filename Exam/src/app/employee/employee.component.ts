import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee',
  standalone: true,
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})


export class EmployeeComponent implements OnInit {
  @Input() employee!: Employee;

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    // Redirect if not authenticated
    if (!this.employeeService.authHeader == null) {
      this.router.navigate(["login"]);
      return;
    }
  }
  editHour (id: number): void{
      this.router.navigate(["edit-hour",id]);
  
  }
}

  /*createNewTimeRegistration(dateWorked: Date, hoursRegistered: number) {

    this.EmployeeService.createTimeRegistration(this.employee.id, dateWorked, hoursRegistered).subscribe(() => {

    });
  }
}*/