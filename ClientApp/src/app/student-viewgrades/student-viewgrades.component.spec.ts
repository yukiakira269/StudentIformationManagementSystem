import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentViewgradesComponent } from './student-viewgrades.component';

describe('StudentViewgradesComponent', () => {
  let component: StudentViewgradesComponent;
  let fixture: ComponentFixture<StudentViewgradesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentViewgradesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentViewgradesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
