import { Injectable } from '@angular/core';
import { BehaviorSubject, distinctUntilChanged, map, ReplaySubject } from 'rxjs';
import { ApplicationUserDto, UserService } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSubject = new BehaviorSubject<ApplicationUserDto>({});
  public currentUser = this.currentUserSubject
    .asObservable()
    .pipe(distinctUntilChanged());
  
  private isAuthenticatedSubject = new ReplaySubject<boolean>(1)
  public isAuthenticated = this.isAuthenticatedSubject.asObservable()

  constructor(private readonly api: UserService) {}

  login(email: string, password: string, rememberMe: boolean = false) {
    return this.api
      .apiUserSignInPost({ email, password, rememberMe })
      .subscribe({
        next: () => {
          this.api.apiUserGetCurrentUserGet().pipe(
            map((realUser) => {
              this.currentUserSubject.next(realUser);
              this.isAuthenticatedSubject.next(true)

              return realUser;
            })
          );
        },
        error: (err) => console.log(err),
      });
  }

  logout() {
    this.api.apiUserSignOutPost().subscribe({
      next: () => {
        this.currentUserSubject.next({})
        this.isAuthenticatedSubject.next(false)
      },
      error: (err) => console.log(err),
    });
  }
}
