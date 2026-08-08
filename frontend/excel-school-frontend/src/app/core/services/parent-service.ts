import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Parent } from '../interfaces/parent';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ParentService {
  public http = inject(HttpClient);

  public getAllParents(): Observable<Parent[]> {
    //retourner la liste des parents
    return this.http.get<Parent[]>(`${environment.API_URL}/parent`);
  }
}
