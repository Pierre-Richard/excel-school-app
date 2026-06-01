import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Student } from '../interfaces/student';
import { environment } from '../../../environments/environment';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private http = inject(HttpClient);
  private students = signal<Student[]>([]);

  public getAllStudents(): Observable<Student[]> {
    //retourner la liste des élèves
    return this.http
      .get<Student[]>(`${environment.API_URL}/student`)
      .pipe(tap((s) => this.students.set(s)));
  }

  public getStudentById(id: number) {
    //retourner un eleve
    return this.http.get<Student>(`${environment.API_URL}/student/${id}`);
  }

  public createStudent(student: Student) {
    return this.http.post<Student>(`${environment.API_URL}/student`, student);
  }

  public updateStudent(id: number, student: Student) {
    //trouver utiliser via son id
    // mise à jour de l'eleve
    // retourner la nouvelle valeur
    return this.http.put<Student>(`${environment.API_URL}/student/${id}`, student);
  }

  public deleteStudent(id: number): Observable<Student> {
    return this.http.delete<Student>(`${environment.API_URL}/student/${id}`);
  }
}
