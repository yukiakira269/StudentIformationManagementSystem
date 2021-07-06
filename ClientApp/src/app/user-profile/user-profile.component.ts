import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  teacher: boolean = false;
  student: boolean = false;
  admin: boolean = false;
  unauth: boolean = false;

  client: HttpClient;
  baseUrl: string;
  constructor(public auth: AuthService,
    public http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.client = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    var data = JSON.stringify(localStorage.getItem("USER_MAIL"));
    var headers = new HttpHeaders().set("Content-type", "application/json");
    this.client.post<string>(this.baseUrl + "user", data, { headers })
      .subscribe(res => {
        if (res.includes("ST")) this.student = true;
        else if (res.includes("TE")) this.teacher = true;
        else if (res.includes("AD")) this.admin = true;
        else this.unauth = true;
      }, err => console.error(err));
  }

}
