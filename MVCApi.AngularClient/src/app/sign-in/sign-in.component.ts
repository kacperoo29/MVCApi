import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent implements OnInit {
  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    rememberMe: new FormControl(false),
  });

  constructor(private readonly authService: AuthService) {}

  ngOnInit(): void {}

  submit() {
    if (this.form.valid) {
      // TODO: Error message on failed login
      this.authService.login(
        this.form.value.email,
        this.form.value.password,
        this.form.value.rememberMe
      );
    } else {
      // TODO: Show error message
    }
  }
}
