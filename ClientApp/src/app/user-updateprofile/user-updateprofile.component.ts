import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, NgForm } from '@angular/forms';

@Component({
  selector: 'app-student',
  templateUrl: './user-updateprofile.component.html',
  styleUrls: ['./user-updateprofile.component.css']
})
export class UserUpdateprofileComponent {

  updateSuccess: boolean;
  isLoaded: boolean = false;
  canAlert: boolean = false;
  curStudent: Student;
  curTeacher: Teacher;
  photoURL: string;
  parse: string;
  client: HttpClient;
  baseUrl: string = "";

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private formBuilder: FormBuilder) {
    this.client = http;
    this.baseUrl = baseUrl;
    this.getUserProfile();
  }

  getUserProfile() {
      var data = JSON.stringify(localStorage.getItem("USER_MAIL"));
      var headers = new HttpHeaders().set("Content-type", "application/json");
      return this.client.post<string>(this.baseUrl + "user", data, { headers })
        .subscribe(res => {
          console.log("Mail: " + data);
          if (res.includes("ST")) {
            this.getStudent();
            this.photoURL = localStorage.getItem("USER_PHOTO");
          }
          else if (res.includes("TE")) {
            this.getTeacher();
            this.photoURL = localStorage.getItem("USER_PHOTO");
          }
          else {
            console.log("Wrong Role");
            this.isLoaded = false;
          }
        }, err => {
          console.error(err);
          this.isLoaded = false;
        });
  }

  getStudent() {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Student>(this.baseUrl + "student/GetStudentInfo", { params })
      .subscribe(res => {
        this.curStudent = res;
        console.log(this.curStudent);
        this.isLoaded = true;
      }, error => console.error(error));
  }

  getTeacher() {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Teacher>(this.baseUrl + "student/GetTeacherInfo", { params })
      .subscribe(res => {
        this.curTeacher = res;
        console.log(this.curTeacher);
        this.isLoaded = true;
      }, error => console.error(error));
  }

  updateStudent(f: NgForm) {
    var selectedBtn = document.activeElement.id;
    if (selectedBtn == "save")
    {
      this.updateSuccess = false;
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Student>(this.baseUrl + "admin/UpdateStudent",
        data, { headers })
        .subscribe(res => {
          this.canAlert = true;
          this.updateSuccess = true;
        }, err => {
          console.error(err);
          this.canAlert = true;
          this.updateSuccess = false;
        });
    }
  }

  updateTeacher(f: NgForm) {
    var selectedBtn = document.activeElement.id;
    if (selectedBtn == "save")
    {
      this.updateSuccess = false;
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Teacher>(this.baseUrl + "admin/UpdateTeacher",
        data, { headers })
        .subscribe(res => {
          this.canAlert = true;
          this.updateSuccess = true;
        }, err => {
          this.canAlert = true;
          this.updateSuccess = false;
          console.error(err);
        });
    }
  }
}

export interface Student {
  StudentId: string,
  Name: string,
  Address: string,
  Email: string,
  Dob: string
}

export interface Teacher {
  TeacherId: string,
  Name: string,
  Email: string,
  Phone: number,
  Faculty: string
}
