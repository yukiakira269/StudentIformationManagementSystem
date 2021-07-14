import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  teacher: boolean;
  student: boolean;
  admin: boolean;
  unauth: boolean;
  isLoaded: boolean;
  role: string;

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
    this.getRole();
  }

  getRole() {
    var data = JSON.stringify(localStorage.getItem("USER_MAIL"));
    var headers = new HttpHeaders().set("Content-type", "application/json");
    return this.client.post<string>(this.baseUrl + "user", data, { headers })
      .subscribe(res => {
        console.log("Mail: " + data);
        if (res.includes("ST")) {
          this.student = true;
          this.role = "Student";
        }
        else if (res.includes("TE")) {
          this.teacher = true;
          this.role = "Teacher";
        }
        else if (res.includes("AD")) {
          this.admin = true;
          this.role = "Admin";
        }
        else
          this.unauth = true;
        if (this.role)
          console.log("Role: " + JSON.stringify(this.role));
        this.isLoaded = true;
      }, err => {
        console.error(err);
        if (!this.role)
          this.isLoaded = true;
      });
  }

}
