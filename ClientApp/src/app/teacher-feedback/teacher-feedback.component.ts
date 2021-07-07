import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';




@Component({
  selector: 'app-teacher-feedback',
  templateUrl: './teacher-feedback.component.html',
  styleUrls: ['./teacher-feedback.component.css']
})

export class TeacherFeedbackComponent implements OnInit {
  private client: HttpClient;
  feedbacks: Feedback[];
  baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl) {
    this.client = http;
    this.baseUrl = baseUrl;
  }
  displayedColumns: string[] = ['studentId', 'feedback'];
  ngOnInit(): void {
    let params = new HttpParams()
      .append("email", localStorage.getItem("USER_MAIL"));

    this.client.get<Feedback[]>(this.baseUrl + "teacher/GetFeedbacks", { params })
      .subscribe(
        res => {
          this.feedbacks = res
        },
        error => console.error(error)
      );
  }
}


export interface Feedback {
  studentId: string;
  feedback: string;
}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

