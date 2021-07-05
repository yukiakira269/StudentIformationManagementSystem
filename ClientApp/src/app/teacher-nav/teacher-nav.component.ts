import { Component } from '@angular/core';

@Component({
  selector: 'app-teacher-nav',
  templateUrl: './teacher-nav.component.html',
  styleUrls: ['./teacher-nav.component.css']
})

export class TeacherNavComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

