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
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UserProfileComponent,
    GuestNavComponent,
    TeacherComponent,
    TeacherNavComponent,
    TeacherViewclassesComponent,
    TeacherViewgradesComponent,
    TeacherFeedbackComponent,
    StudentComponent,
    StudentNavComponent
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
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'home', component: HomeComponent },
      { path: 'teacher', component: TeacherComponent },
      { path: 'teacher/viewclass', component: TeacherViewclassesComponent },
      { path: 'teacher/viewgrades', component: TeacherViewgradesComponent },
      { path: 'teacher/feedbacks', component: TeacherFeedbackComponent },
      { path: 'student', component: StudentComponent }
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
