import { Component, Input, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../service/employee.service';
import { Router } from '@angular/router';
import {FormsModule} from '@angular/forms'


@Component({
  selector: 'app-employee',
  standalone: true,
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  imports: [FormsModule],
})


export class EmployeeComponent implements OnInit {
  @Input() employee!: Employee;
  dateWorked: Date = new Date(); // Initialize with current date
  hoursRegistered: number = 0; // Initialize with zero hours
  employeeId: number = 1;

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    // Redirect if not authenticated
    if (!this.employeeService.authHeader) {
      this.router.navigate(["login"]);
      return;
    }
  }

  createNewRegistration() {
    console.log('checktime')
    this.employeeService.createRegistration(this.employeeId, this.dateWorked, this.hoursRegistered)
      .subscribe(() => {
        // Reset the input fields after successful submission if needed
        this.dateWorked = new Date();
        this.hoursRegistered = 0;
        this.employeeService.getEmployee(this.employeeId)
        .subscribe((updatedEmployee) => {
          // Update the employee object with the updated data
          this.employee = updatedEmployee;
      });
  });
}
}



 