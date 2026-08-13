import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Classe } from '../interfaces/classe';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClasseService {
  public http = inject(HttpClient);

  public getAllClasses(): Observable<Classe[]> {
    return this.http.get<Classe[]>(`${environment.API_URL}/class`);
  }
}
