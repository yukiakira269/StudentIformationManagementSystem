import { Component } from '@angular/core';

@Component({
  selector: 'app-guest-nav',
  templateUrl: './guest-nav.component.html',
  styleUrls: ['./guest-nav.component.css']
})

export class GuestNavComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

