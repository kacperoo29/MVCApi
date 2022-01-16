import { Component } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'eshop';
  isAuthenticated: boolean = false

  constructor(private readonly authService: AuthService) {
    authService.isAuthenticated
      .subscribe((value) => this.isAuthenticated = value)
  }
}
