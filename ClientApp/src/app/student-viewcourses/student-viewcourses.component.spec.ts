import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentViewcoursesComponent } from './student-viewcourses.component';

describe('TeacherViewclassesComponent', () => {
  let component: StudentViewcoursesComponent;
  let fixture: ComponentFixture<StudentViewcoursesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentViewcoursesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentViewcoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
