import { HttpClient, HttpParams } from '@angular/common/http';
import { formattedError } from '@angular/compiler';
import { error } from '@angular/compiler/src/util';
import { Component, Inject, Input } from '@angular/core';
import { map } from 'rxjs/operators';
import { forEachChild } from 'typescript';


@Component({
  selector: 'app-student-viewcourses',
  templateUrl: './student-viewcourses.component.html',
  styleUrls: ['./student-viewcourses.component.css']
})

export class StudentViewcoursesComponent {

  public courses: Course[];
  public checkRegis: Class;
  public registered: Course[];
  public classes: Class[];
  public student: Student;
  public canceled: Class;
  public canAlert: boolean = false;
  public alterId: string;
  email: string;
  url: string = "";
  client: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.client = http;
    this.email = localStorage.getItem("USER_MAIL");
    this.getCourses();
  }

  getCourses() {
    this.registered = null;
    return this.client.get<Course[]>(this.url + "student/GetCourseList")
      .subscribe(res => {
        this.courses = res;
        console.log(res);
    }, error => console.error(error));
  }

  getRegisteredCourses() {
    this.courses = null;
    let params = new HttpParams()
      .append('email', this.email);
    return this.client.get<Course[]>(this.url + "student/GetRegisteredCourses", { params })
      .subscribe(res => {
        this.registered = res;
        console.log(res);
        this.getRegisteredClasses();
    }, error => console.error(error));
  }

  getRegisteredClasses() {
    let params = new HttpParams()
      .append('email', this.email);
    return this.client.get<Class[]>(this.url + "student/GetRegisteredClasses", { params })
      .subscribe(res => {
        this.classes = res;
        console.log(res);
      }, error => console.error(error));
  }

  // Register
  registerCourse(courseId: string) {
    let params = new HttpParams()
      .append('courseId', courseId)
      .append('email', this.email);
    return this.client.get<Class>(this.url + "student/RegisterCourse", { params })
      .subscribe(res => {
        console.log(res);
        this.checkRegis = res;
        this.canAlert = true;
        this.alterId = courseId
      }, error => { console.error(error); this.alterId = courseId });
  }

  // Cancel Register

  cancelCourse(classId: string) {
    let params = new HttpParams()
      .append('classId', classId)
      .append('email', this.email);
    return this.client.get<Class>(this.url + "student/CancelCourse", { params })
      .subscribe(
        res => {
          this.canceled = res;
          console.log(this.canceled);
          this.getRegisteredCourses()
        },
        err => { console.error(err); }
      );
  }
}


interface Course {
  CourseId: string,
  Name: string,
  Fee: string
}

interface Student {
  StudentId: string,
  Name: string,
  Email: string,
  Address: string
}

interface Class {
  ClassId: string,
  CourseId: string,
  TeacherId: string,
  NumOfStudent: number,
}
