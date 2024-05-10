import { EmployeeService} from '../service/employee.service';
import { Employee} from '../model/employee';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit-hoursregistered',
  standalone: true,
  imports: [],
  templateUrl: './edit-hoursregistered.component.html',
  styleUrls: ['./edit-hoursregistered.component.css']
})


export class EditHoursregisteredComponent implements OnInit{
  @Input() id!: number;
  employee!: Employee
  constructor(private employeeService: EmployeeService){
  }
  ngOnInit(){
    this.employeeService.getEmployee(this.id).subscribe((employee): any => {
      this.employee = employee;
    });
  }
}
