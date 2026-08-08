import { CommonModule } from '@angular/common';
import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { StudentService } from '../../../core/services/student-service';
import { Student } from '../../../core/interfaces/student';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { SelectModule } from 'primeng/select';
import { InputTextModule } from 'primeng/inputtext';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Parent } from '../../../core/interfaces/parent';
import { ParentService } from '../../../core/services/parent-service';
@Component({
  selector: 'app-students-list',
  imports: [
    CommonModule,
    CardModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    ReactiveFormsModule,
    SelectModule,
  ],
  templateUrl: './students-list.html',
  styleUrl: './students-list.scss',
})
export class StudentsList {
  public studentService = inject(StudentService);
  public parentService = inject(ParentService);
  public students = signal<Student[]>([]);
  public parents = signal<Parent[]>([]);
  public visible = signal(false);
  private fb = inject(FormBuilder);

  myForm = this.fb.nonNullable.group({
    firstname: ['', Validators.required],
    name: ['', Validators.required],
    studentNumber: [0, Validators.required],
    className: ['', Validators.required],
    parentId: [0, Validators.required],
    birthDate: ['', Validators.required],
  });
  public parentFiltered = computed(() => {
    return this.parents().map((p) => {
      return {
        id: p.id,
        name: p.name,
        firstname: p.firstname,
        fullname: p.name + '-' + p.firstname,
      };
    });
  });
  showDialog() {
    this.parentService.getAllParents().subscribe((parents) => {
      this.parents.set(parents);
    });
    this.visible.set(true);
  }

  onSubmit() {
    if (this.myForm.valid) {
      let valueForm = this.myForm.getRawValue();
      let value = {
        ...valueForm,
        birthDate: new Date(valueForm.birthDate!).toISOString().split('T')[0],
      };
      console.log('Reponse', value);
      console.log(JSON.stringify(value));
      this.studentService.createStudent(value).subscribe(() => {
        this.visible.set(false);
      });
    }
  }
}
