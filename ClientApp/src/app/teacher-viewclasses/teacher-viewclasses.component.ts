import { HttpClient, HttpParams } from '@angular/common/http';
import { formattedError } from '@angular/compiler';
import { error } from '@angular/compiler/src/util';
import { Component, Inject, Input } from '@angular/core';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-teacher-viewclasses',
  templateUrl: './teacher-viewclasses.component.html',
  styleUrls: ['./teacher-viewclasses.component.css']
})
export class TeacherViewclassesComponent {


  itemsVisibility = [];
  public classes: Class[];
  public students: Student[];
  url: string = "";
  client: HttpClient;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.client = http;
    this.getClasses().subscribe(res => {
      this.classes = res;
      console.log(res);
    }, error => console.error(error));
  }


  getClasses() {
    let params = new HttpParams()
      .append('email', localStorage.getItem("USER_MAIL"));
    return this.client.get<Class[]>(this.url + "teacher/GetClassList", { params });
  }

  getStudentList(classId: string) {
    let params = new HttpParams()
      .append('classId', classId);
    return this.client.get<Student[]>(this.url + "teacher/GetStudentList", { params })
      .subscribe(res => {
        this.students = res;
        console.log(res);
      }, err => console.error(err));
  }


  closeAllButThis(index: number) {
    this.itemsVisibility[index] = true;
    for (let i = 0; i < this.itemsVisibility.length; i++) {
      if (i !== index) {
        this.itemsVisibility[i] = false;
      }
    }
  }

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
