import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../model/login';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated() {
    throw new Error('Method not implemented.');
  }
  baseUrl: string = "http://localhost:5057/api";
  constructor(private http: HttpClient) {
  }
  authenticate(username: String, password: String): Observable<Login> {
      return this.http.post<Login>('http://localhost:5057/api/Login', {
        username: username,
        password: password
      });
    }
}
