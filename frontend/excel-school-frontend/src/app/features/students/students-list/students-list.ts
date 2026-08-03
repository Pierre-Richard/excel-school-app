import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { StudentService } from '../../../core/services/student-service';
import { Student } from '../../../core/interfaces/student';
import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-students-list',
  imports: [
    CommonModule,
    CardModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    ReactiveFormsModule,
  ],
  templateUrl: './students-list.html',
  styleUrl: './students-list.scss',
})
export class StudentsList implements OnInit {
  public studentService = inject(StudentService);
  public students = signal<Student[]>([]);
  public visible = signal(false);
  private fb = inject(FormBuilder);

  ngOnInit(): void {
    //toSignal(this.studentService.getAllStudents(),{intialV})
  }

  myForm = this.fb.nonNullable.group({
    firstname: ['', Validators.required],
    name: ['', Validators.required],
    studentNumber: [0, Validators.required],
    className: ['', Validators.required],
    parentName: ['', Validators.required],
    birthDate: ['', Validators.required],
  });
  showDialog() {
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
