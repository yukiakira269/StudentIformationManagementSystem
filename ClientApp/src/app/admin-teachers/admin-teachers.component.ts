import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-admin-teachers',
  templateUrl: './admin-teachers.component.html',
  styleUrls: ['./admin-teachers.component.css']
})
export class AdminTeachersComponent implements OnInit {
  client: HttpClient;
  baseUrl: string;
  teachers: Teacher[];
  updateSuccess: boolean;

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getTeachers();
  }

  getTeachers() {
    this.client.get<Teacher[]>(this.baseUrl + ("admin/GetTeachers"))
      .subscribe(
        res => {
          this.teachers = res;
          console.log(res);
        },
        err => console.error(err)
      )
  }

  updateTeacher(f: NgForm) {
    var selectedBtn = document.activeElement.id;
    if (selectedBtn == "save") {

      this.updateSuccess = false;
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Teacher>(this.baseUrl + "admin/UpdateTeacher",
        data, { headers })
        .subscribe(res => {
          this.updateSuccess = true;
        }, err => {
          console.error(err);
        });
    } else if (selectedBtn == "remove") {
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Teacher>(this.baseUrl + "admin/RemoveTeacher",
        data, { headers })
        .subscribe(res => {
          this.getTeachers();
        }, err => {
          console.error(err);
        });
    }
  }

}

export interface Teacher {
  TeacherId: string,
  Name: string,
  Email: string,
  Phone: number,
  Faculty: string
}
