import { Component } from '@angular/core';

@Component({
  selector: 'app-student-nav',
  templateUrl: './student-nav.component.html',
  styleUrls: ['./student-nav.component.css']
})

export class StudentNavComponent {
  public email: string = localStorage.getItem("USER_MAIL").split("@")[0];
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

