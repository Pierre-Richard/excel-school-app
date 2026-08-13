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
import { ClasseService } from '../../../core/services/classe-service';
import { Classe } from '../../../core/interfaces/classe';
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
export class StudentsList implements OnInit {
  public studentService = inject(StudentService);
  public parentService = inject(ParentService);
  public classeService = inject(ClasseService);
  public students = signal<Student[]>([]);
  public parents = signal<Parent[]>([]);
  public classes = signal<Classe[]>([]);
  public visible = signal(false);
  private fb = inject(FormBuilder);
  //public students$!: Observable<Student[]>;

  ngOnInit(): void {
    this.studentService.getAllStudents().subscribe((student) => {
      this.students.set(student);
    });
  }

  myForm = this.fb.nonNullable.group({
    firstname: ['', Validators.required],
    name: ['', Validators.required],
    studentNumber: [0, Validators.required],
    classId: [0, Validators.required],
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
  public classesFiltered = computed(() => {
    return this.classes().map((c) => {
      return {
        id: c.id,
        name: c.name,
        level: c.level,
        fullname: c.name,
      };
    });
  });

  public listeStudentsByClasses = computed(() => {
    //parcourir la liste des eleves pour trouver sa classe assoicé
    return this.students().map((student) => {
      // parcourir mon tableau de classes et trouver la classes qui correspond à l'eleve
      let studentClasse = this.classes().find((c) => c.id == student.classId);
      //je retourne une liste d'eleves avec leur classes associés
      return {
        id: student.id,
        userId: student.userId,
        classId: student.classId,
        parentId: student.parentId,
        name: student.name,
        firstname: student.firstname,
        studentNumber: student.studentNumber,
        birthDate: student.birthDate,
        studentClasse: studentClasse,
      };
    });
  });

  showDialog() {
    this.parentService.getAllParents().subscribe((parents) => {
      this.parents.set(parents);
    });
    this.classeService.getAllClasses().subscribe((classes) => {
      this.classes.set(classes);
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
