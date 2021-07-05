import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherViewgradesComponent } from './teacher-viewgrades.component';

describe('TeacherViewgradesComponent', () => {
  let component: TeacherViewgradesComponent;
  let fixture: ComponentFixture<TeacherViewgradesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherViewgradesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherViewgradesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
