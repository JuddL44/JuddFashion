import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/auth`;

  private currentUserSubject = new BehaviorSubject<User | null>(null);
  public currentUser$ = this.currentUserSubject.asObservable();

  constructor() {
    this.loadUserFromToken();
  }

  private loadUserFromToken() {
    const token = this.getToken();
    if (token) {
      try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        console.log('JWT Payload:', payload);
        const user: User = {
          id: parseInt(
            payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
          ),
          username: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
          email: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
          createdAt: payload.createdAt,
        };
        console.log('Parsed user:', user);
        this.currentUserSubject.next(user);
      } catch (error) {
        this.logout();
      }
    }
  }

  register(username: string, email: string, password: string): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}/register`, {
        username,
        email,
        password,
      })
      .pipe(tap((response) => this.handleAuthResponse(response)));
  }

  login(email: string, password: string): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}/login`, {
        email,
        password,
      })
      .pipe(tap((response) => this.handleAuthResponse(response)));
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSubject.next(null);
  }

  private handleAuthResponse(response: AuthResponse) {
    localStorage.setItem('token', response.token);
    this.currentUserSubject.next(response.user);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  getCurrentUser(): User | null {
    return this.currentUserSubject.value;
  }
}

interface User {
  id: number;
  username: string;
  email: string;
  createdAt: string;
}

interface AuthResponse {
  token: string;
  user: User;
}
