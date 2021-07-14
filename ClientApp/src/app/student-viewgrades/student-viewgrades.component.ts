import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, NgForm } from '@angular/forms';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-student-viewgrades',
  templateUrl: './student-viewgrades.component.html',
  styleUrls: ['./student-viewgrades.component.css']
})
export class StudentViewgradesComponent {

  itemsVisibility = [];
  itemsVisibility2 = [];

  public grades: Grade[];
  public currentStudent: Student;
  public email: string = "";
  public canAlert: boolean = false;
  client: HttpClient;
  url: string = "";

  gradeStatus: string;
  errors: string[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private formBuilder: FormBuilder) {
    this.client = http;
    this.url = baseUrl;
    this.email = localStorage.getItem("USER_MAIL");
    this.getUser(this.email);
    this.getGrades();
  }

  getUser(email: string) {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Student>(this.url + "student/GetStudentInfo", { params })
      .subscribe(res => {
        this.currentStudent = res;
        console.log(res)
      }, err => console.error(err));
  }

  getGrades() {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Grade[]>(this.url + "student/GetGradeList", { params })
      .subscribe(res => { this.grades = res; console.log(res) }, err => console.error(err));
  }

}

interface Grade {
  studentId: string,
  courseId: string,
  grade: number
}

interface Student {
  StudentId: string,
  Name: string,
  Email: string,
  Address: string
}


