import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/api';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent implements OnInit {
  form = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  message: string | null = null;

  constructor(private readonly userService: UserService) {}

  ngOnInit(): void {}

  submit() {
    if (this.form.valid) {
      this.userService.apiUserCreateUserPost(this.form.value).subscribe({
        next: () => {
          this.message = 'Successfully created user account';
        },
        error: (e) => {
          this.message = 'Failed to create user account';
        },
      });
    }
  }
}
