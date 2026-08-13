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
export class StudentProfil {}
