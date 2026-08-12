import { Component, inject, OnInit } from '@angular/core';
import { StudentsList } from '../students-list/students-list';
import { Observable } from 'rxjs';
import { Student } from '../../../core/interfaces/student';
import { StudentService } from '../../../core/services/student-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-profil',
  imports: [StudentsList, CommonModule],
  templateUrl: './student-profil.html',
  styleUrl: './student-profil.scss',
})
export class StudentProfil implements OnInit {
  public studentService = inject(StudentService);
  public students$!: Observable<Student[]>;

  ngOnInit(): void {
    this.students$ = this.studentService.getAllStudents();
    console.log('Liste des Eleves', this.students$);
  }
}
