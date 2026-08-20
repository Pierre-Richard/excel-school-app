import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { User } from '../interfaces/user';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public http = inject(HttpClient);

  public getUserStudent(): Observable<User[]> {
    // retourner la liste des users des eleves
    return this.http.get<User[]>(`${environment.API_URL}/user/students`);
  }
}
