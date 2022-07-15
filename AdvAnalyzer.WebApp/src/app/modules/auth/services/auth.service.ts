import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl = 'https://localhost:44309/api/auth/';
  public isAuthenticated: boolean = false;

  constructor(private http: HttpClient) { 
    this.isAuthenticated = this.getToken();
  }

  login(data: any): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'login', data);
  }

  register(data: any): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'register', data);
  }

  getToken(): boolean {
    return !!localStorage.getItem("token");
  }
}
