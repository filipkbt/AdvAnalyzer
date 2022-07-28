import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../models/login.model';
import { Register } from '../models/register.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public isAuthenticated: boolean = false;

  constructor(private http: HttpClient) { 
    this.isAuthenticated = this.getToken();
  }

  login(data: Login): Observable<any> {
    return this.http.post<any>(environment.apiUrl + 'auth/login', data);
  }

  register(data: Register): Observable<any> {
    return this.http.post<any>(environment.apiUrl + 'auth/register', data);
  }

  getToken(): boolean {
    return !!localStorage.getItem("token");
  }

  getEmail(): string | null{
    return localStorage.getItem("email");
  }

  getUserId(): number {
    return Number(localStorage.getItem("userId"));
  }
}
