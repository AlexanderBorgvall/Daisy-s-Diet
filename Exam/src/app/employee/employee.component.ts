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
  hoursWorked: number = 0; // Initialize with zero hours

  constructor(private employeeService: EmployeeService, private router: Router) {}

  ngOnInit(): void {
    // Redirect if not authenticated
    if (!this.employeeService.authHeader) {
      this.router.navigate(["login"]);
      return;
    }
  }

  createNewRegistration() {
    this.employeeService.createRegistration(this.employee.id, this.dateWorked, this.hoursWorked)
      .subscribe(() => {
        // Reset the input fields after successful submission if needed
        this.dateWorked = new Date();
        this.hoursWorked = 0;
        this.employeeService.getEmployee(this.employee.id)
        .subscribe((updatedEmployee) => {
          // Update the employee object with the updated data
          this.employee = updatedEmployee;
      });
  });
}
}



 