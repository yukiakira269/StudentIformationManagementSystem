import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AngularFireModule } from '@angular/fire';
import { AngularFirestoreModule } from '@angular/fire/firestore';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatButtonModule } from '@angular/material/button';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { environment } from '../environments/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { GuestNavComponent } from './guest-nav/guest-nav.component';
import { TeacherComponent } from './teacher/teacher.component';
import { TeacherNavComponent } from './teacher-nav/teacher-nav.component';
import { TeacherViewclassesComponent } from './teacher-viewclasses/teacher-viewclasses.component';
import { TeacherViewgradesComponent } from './teacher-viewgrades/teacher-viewgrades.component';
import { TeacherFeedbackComponent } from './teacher-feedback/teacher-feedback.component';

import { StudentComponent } from './student/student.component';
import { StudentNavComponent } from './student-nav/student-nav.component';
import { StudentViewcoursesComponent } from './student-viewcourses/student-viewcourses.component';
import { StudentViewgradesComponent } from './student-viewgrades/student-viewgrades.component';

import { CoursePaymentComponent } from './course-payment/course-payment.component';
import { AdminNavComponent } from './admin-nav/admin-nav.component';
import { AdminStudentsComponent } from './admin-students/admin-students.component';
import { AdminTeachersComponent } from './admin-teachers/admin-teachers.component';
import { AdminCoursesComponent } from './admin-courses/admin-courses.component';
import { AdminClassesComponent } from './admin-classes/admin-classes.component';
import { AdminComponent } from './admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserProfileComponent,
    GuestNavComponent,
    TeacherComponent,
    TeacherNavComponent,
    TeacherViewclassesComponent,
    TeacherViewgradesComponent,
    TeacherFeedbackComponent,

    StudentComponent,
    StudentNavComponent,
    StudentViewcoursesComponent,
    StudentViewgradesComponent,
    CoursePaymentComponent,

    AdminNavComponent,
    AdminStudentsComponent,
    AdminTeachersComponent,
    AdminCoursesComponent,
    AdminClassesComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFirestoreModule,
    AngularFireAuthModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: UserProfileComponent, pathMatch: 'full' },
      { path: 'home', component: UserProfileComponent },
      { path: 'teacher', component: TeacherComponent },
      { path: 'teacher/viewclass', component: TeacherViewclassesComponent },
      { path: 'teacher/viewgrades', component: TeacherViewgradesComponent },
      { path: 'teacher/feedbacks', component: TeacherFeedbackComponent },

      { path: 'student', component: StudentComponent },
      { path: 'student/viewcourses', component: StudentViewcoursesComponent },
      { path: 'student/viewgrades', component: StudentViewgradesComponent },

      { path: 'course', component: CoursePaymentComponent },
      { path: 'student', component: StudentComponent },
      { path: 'student/register', component: CoursePaymentComponent },
      { path: 'admin/teachers', component: AdminTeachersComponent },
      { path: 'admin/students', component: AdminStudentsComponent },
      { path: 'admin/courses', component: AdminCoursesComponent },
      { path: 'admin/classes', component: AdminClassesComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
