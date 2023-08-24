import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'app-order-condirmation',
  templateUrl: './order-condirmation.component.html',
  styleUrls: ['./order-condirmation.component.css']
})
export class OrderCondirmationComponent {
  constructor(private router: Router) { }

  goToHomePage() {
    this.router.navigate(['home']);
  }
}
