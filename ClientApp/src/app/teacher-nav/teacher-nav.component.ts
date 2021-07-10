import { Component } from '@angular/core';

@Component({
  selector: 'app-teacher-nav',
  templateUrl: './teacher-nav.component.html',
  styleUrls: ['./teacher-nav.component.css']
})

export class TeacherNavComponent {
  public email: string = localStorage.getItem("USER_MAIL").split("@")[0];
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

