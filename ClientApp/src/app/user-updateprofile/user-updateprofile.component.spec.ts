import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserUpdateprofileComponent } from './user-updateprofile.component';

describe('UserUpdateprofileComponent', () => {
  let component: UserUpdateprofileComponent;
  let fixture: ComponentFixture<UserUpdateprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserUpdateprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserUpdateprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
