import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';




@Component({
  selector: 'app-teacher-feedback',
  templateUrl: './teacher-feedback.component.html',
  styleUrls: ['./teacher-feedback.component.css']
})

export class TeacherFeedbackComponent implements OnInit {
  private client: HttpClient;
  feedbacks: Feedback[];
  baseUrl: string;
  feedbackSuccess: boolean;
  errorMsg: string;

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

  feedbackStudent(f: NgForm) {
    this.feedbackSuccess = false;
    var data = JSON.stringify(f.value);
    var headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.client.post<Feedback>(this.baseUrl + "teacher/Feedback",
      data, { headers })
      .subscribe(res => {
        this.feedbackSuccess = true
      }, err => {
        this.errorMsg = "Feedback unsuccessful";
        console.error(err);
      });
  }


}

export interface Feedback {
  teacherId: string;
  studentId: string;
  feedback1: string;
}


