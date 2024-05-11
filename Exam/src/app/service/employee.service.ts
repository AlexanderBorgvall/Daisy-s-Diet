import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../model/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl: string = "http://localhost:5057/api";

  constructor(private http: HttpClient) {}

  // Retrieve the authHeader directly from localStorage
  get authHeader(): string { return localStorage["headerValue"]; }

  // Check if the user is authenticated
  isAuthenticated(): boolean {
    return !!this.authHeader; // Checks if the authHeader is non-null and non-empty.
  }

  // Fetch all employees with authorization
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseUrl}/employees`, {
      headers: { "Authorization": this.authHeader }
    });
  }

  // Fetch a single employee by ID
  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseUrl}/employees/${id}`, {
      headers: { "Authorization": this.authHeader }
    });
  }
  createRegistration(employeeId: number, dateWorked: Date, hoursWorked: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/employees/${employeeId}/registrations`, {
      dateWorked: dateWorked,
      hoursWorked: hoursWorked
    }, {
      headers: { "Authorization": this.authHeader }
    });
  }
}

