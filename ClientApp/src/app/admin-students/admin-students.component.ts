import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-admin-students',
  templateUrl: './admin-students.component.html',
  styleUrls: ['./admin-students.component.css']
})
export class AdminStudentsComponent implements OnInit {
  client: HttpClient;
  baseUrl: string;
  students: Student[];
  updateSuccess: boolean;
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents() {
    this.client.get<Student[]>(this.baseUrl + ("admin/GetStudents"))
      .subscribe(
        res => {
          this.students = res;
          console.log(res);
        },
        err => console.error(err)
      )
  }


  updateStudent(f: NgForm) {
    var selectedBtn = document.activeElement.id;
    if (selectedBtn == "save") {
      this.updateSuccess = false;
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Student>(this.baseUrl + "admin/UpdateStudent",
        data, { headers })
        .subscribe(res => {
          this.updateSuccess = true;
        }, err => {
          console.error(err);
        });
    }
    else if (selectedBtn == "promote") {
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Student>(this.baseUrl + "admin/PromoteStudent",
        data, { headers })
        .subscribe(res => {
          location.reload();
          this.getStudents();
        }, err => {
          console.error(err);
        });
    }
    else if (selectedBtn == "remove") {
      var data = JSON.stringify(f.value);
      var headers = new HttpHeaders().set("Content-Type", "application/json");
      return this.client.post<Student>(this.baseUrl + "admin/RemoveStudent",
        data, { headers })
        .subscribe(res => {
          this.getStudents();
        }, err => {
          console.error(err);
        });
    }
  }

  authorise(f: NgForm) {
    this.updateSuccess = false;
    var data = JSON.stringify(f.value);
    var headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.client.post<Student>(this.baseUrl + "admin/AuthoriseStudent",
      data, { headers })
      .subscribe(res => {
        this.updateSuccess = true;
        console.log(res);
        this.getStudents();
      }, err => {
        console.error(err);
      });
  }
}



export interface Student {
  StudentId: string,
  Name: string,
  Address: string,
  Email: string,
}
