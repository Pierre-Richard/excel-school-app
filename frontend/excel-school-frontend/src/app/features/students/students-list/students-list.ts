import { CommonModule } from '@angular/common';
import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { Classe } from '../../../core/interfaces/classe';
import { Parent } from '../../../core/interfaces/parent';
import { Student } from '../../../core/interfaces/student';
import { ClasseService } from '../../../core/services/classe-service';
import { ParentService } from '../../../core/services/parent-service';
import { StudentService } from '../../../core/services/student-service';
import { UserService } from '../../../core/services/user-service';
import { User } from '../../../core/interfaces/user';
import { MessageModule } from 'primeng/message';
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
    FormsModule,
    MessageModule,
  ],
  templateUrl: './students-list.html',
  styleUrl: './students-list.scss',
})
export class StudentsList implements OnInit {
  public studentService = inject(StudentService);
  public parentService = inject(ParentService);
  public classeService = inject(ClasseService);
  public userService = inject(UserService);
  private fb = inject(FormBuilder);

  public students = signal<Student[]>([]);
  public parents = signal<Parent[]>([]);
  public classes = signal<Classe[]>([]);
  public visible = signal(false);
  public selectedClasse = signal<number>(0);
  public value = signal<number>(0);
  public users = signal<User[]>([]);

  ngOnInit(): void {
    //call api de ma liste de classe à initialisation de mon composant
    this.classeService.getAllClasses().subscribe((classes) => {
      this.classes.set(classes);
    });
    // call api de ma liste des eleves à initialisation de mon composant
    this.studentService.getAllStudents().subscribe((student) => {
      console.log(student);
      this.students.set(student);
    });
  }

  formDialog = this.fb.nonNullable.group({
    firstname: ['', Validators.required],
    name: ['', Validators.required],
    studentNumber: [0, Validators.required],
    classId: [0, [Validators.required, Validators.min(1)]],
    userId: [0, [Validators.required, Validators.min(1)]],
    parentId: [0, [Validators.required, Validators.min(1)]],
    birthDate: ['', Validators.required],
  });
  public parentFiltered = computed(() => {
    // retourner la liste des parents
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
    //ajouter une nouvelle valeur (object) à ma liste de classes
    // // id 0 car aucune classe réelle ne porte cet id
    let updateArray = [...this.classes(), { id: 0, name: 'tous', level: '' }];
    // retourner mon tableau
    let array = updateArray.map((u) => {
      return {
        id: u.id,
        level: u.level,
        name: u.name,
      };
    });
    return array;
  });

  public studentsListFilteredByClass = computed(() => {
    // si utilisateur ne selectionne rien
    if (this.selectedClasse() === 0) {
      //retourner ma liste d'eleves
      return this.students();
    }
    //filter sur ma liste d'eleves et verfier que l'id de la class de mon eleve
    // et égale à id que j'ai selectionné
    return this.students().filter((student) => {
      return student.classId == this.selectedClasse();
    });
  });

  showDialog() {
    // call api de la liste des parents avant que le dialog ne s'affiche !
    this.parentService.getAllParents().subscribe((parents) => {
      this.parents.set(parents);
    });

    this.userService.getUserStudent().subscribe((user) => {
      this.users.set(user);
    });

    this.visible.set(true);
  }

  onSubmit() {
    if (this.formDialog.invalid) {
      this.formDialog.markAllAsTouched();
      return;
    }
    let valueForm = this.formDialog.getRawValue();
    this.studentService.createStudent(valueForm).subscribe(() => {
      this.visible.set(false);
    });
  }

  getSelectedClasse(event: any) {
    //recupere l'id de la classe selectionné
    this.selectedClasse.set(event.value);
  }
}
