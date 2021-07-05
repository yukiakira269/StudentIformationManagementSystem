import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherViewclassesComponent } from './teacher-viewclasses.component';

describe('TeacherViewclassesComponent', () => {
  let component: TeacherViewclassesComponent;
  let fixture: ComponentFixture<TeacherViewclassesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherViewclassesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherViewclassesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
