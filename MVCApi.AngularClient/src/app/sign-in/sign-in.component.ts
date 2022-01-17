import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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

  public isLoggedIn: boolean = false;

  private returnUrl: string = ''

  constructor(
    private readonly authService: AuthService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {
    this.authService.isAuthenticated.subscribe(
      (val) => (this.isLoggedIn = val)
    );
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.returnUrl = params['returnUrl'];
    });
  }

  submit() {
    if (this.form.valid) {
      this.authService.login(
        this.form.value.email,
        this.form.value.password,
        this.form.value.rememberMe
      );

      this.authService.isAuthenticated.subscribe({
        next: (res) => {
          if (res) {
            this.router.navigate([this.returnUrl])
          } else {
            // TODO: Error message on failed login
          }
        },
      });
    } else {
      // TODO: Show error message
    }
  }
}
