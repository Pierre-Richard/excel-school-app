import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentProfil } from './student-profil';

describe('StudentProfil', () => {
  let component: StudentProfil;
  let fixture: ComponentFixture<StudentProfil>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentProfil],
    }).compileComponents();

    fixture = TestBed.createComponent(StudentProfil);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
