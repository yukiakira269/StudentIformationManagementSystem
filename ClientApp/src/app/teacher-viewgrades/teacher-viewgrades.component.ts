import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, NgForm } from '@angular/forms';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-teacher-viewgrades',
  templateUrl: './teacher-viewgrades.component.html',
  styleUrls: ['./teacher-viewgrades.component.css']
})
export class TeacherViewgradesComponent {

  itemsVisibility = [];
  itemsVisibility2 = [];

  classes: Class[];
  students: Student[];
  grades: Grade[];
  client: HttpClient;
  url: string = "";

  isLoaded: boolean = false;
  gradeStatus: string;
  errors: string[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private formBuilder: FormBuilder) {
    this.client = http;
    this.url = baseUrl;
    this.getClasses().subscribe(res => this.classes = res, err => console.error(err));
  }


  getClasses() {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Class[]>(this.url + "teacher/GetClassList", { params });
  }

  getGrade(studentId: string) {
    this.isLoaded = false;
    this.gradeStatus = null;
    let params = new HttpParams()
      .append('id', studentId);
    return this.client.get<Grade[]>(this.url + "teacher/GetGrade", { params })
      .subscribe(
        res => {
          this.grades = res;
          console.log("Grade" + res);
          this.isLoaded = true;
        },
        err => console.error(err),
      );
  }

  gradeStudent(f: NgForm) {
    var data = JSON.stringify(f.value);
    var headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.client.post<Grade>(this.url + "teacher/GradeStudent",
      data, { headers })
      .subscribe(res => {
        this.gradeStatus = "Student graded!"
      }, err => {
        this.gradeStatus = "Grading failed! Please try again!"
        console.error(err);
      });
  }

  getStudentList(classId: string) {
    this.isLoaded = false;
    this.gradeStatus = null;
    let params = new HttpParams()
      .append('classId', classId);
    return this.client.get<Student[]>(this.url + "teacher/GetStudentList", { params })
      .subscribe(res => {
        this.students = res;
        console.log("Student" + this.students);
        this.isLoaded = true;
      }, err => console.error(err));
  }


  closeAllButThis(index: number) {
    this.itemsVisibility[index] = !this.itemsVisibility[index];
    for (let i = 0; i < this.itemsVisibility.length; i++) {
      if (i !== index) {
        this.itemsVisibility[i] = false;
      }
    }
  }

  closeAllButThis2(index: number) {
    this.itemsVisibility2[index] = !this.itemsVisibility2[index];
    for (let i = 0; i < this.itemsVisibility2.length; i++) {
      if (i !== index) {
        this.itemsVisibility2[i] = false;
      }
    }
  }

}



interface Class {
  ClassId: string,
  NumOfStudent: number,
}

interface Student {
  StudentId: string,
  Name: string,
}

interface Grade {
  studentId: string,
  courseId: string,
  grade: number
}


