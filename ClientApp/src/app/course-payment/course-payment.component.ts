import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-course-payment',
  templateUrl: './course-payment.component.html',
  styleUrls: ['./course-payment.component.css']
})
export class CoursePaymentComponent implements OnInit {
  client: HttpClient;
  baseUrl: string;

  courses: Course[];
  displayedColumns: string[] = ['CourseId', 'Name', 'Fee', 'Register'];

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.client.get<Course[]>(this.baseUrl + ("course/GetCourses"))
      .subscribe(
        res => {
          this.courses = res;
          console.log(res);
        },
        err => console.error(err)
      )
  }

  registerCourse(f: NgForm) {
    
  }

}
export interface Course {
  courseId: string,
  name: string,
  fee: number,
}
