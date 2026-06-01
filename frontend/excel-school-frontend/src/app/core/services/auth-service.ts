import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponse } from '../interfaces/login-response';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private httpClient = inject(HttpClient);

  public login(email: string, password: string): Observable<LoginResponse> {
    //Reçoit email et password (paramètres)
    //Envoie une requête HTTP POST au backend
    //Retourne un Observable<LoginResponse>
    return this.httpClient.post<LoginResponse>(`${environment.API_URL}/auth/login`, {
      email,
      password,
    });
  }

  register() {}

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    //je recupere le token puis je le renvois
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    if (this.getToken()) {
      return true;
    } else {
      return false;
    }
  }

  getUserRole(): string | null {
    // je recois les roles de utilisateur
    let role = localStorage.getItem('role');
    // je retourne le role
    return role;
  }
  getUser(): string | null {
    // je recois les roles de utilisateur
    let user = localStorage.getItem('user');
    // je retourne le role
    return user;
  }
}
