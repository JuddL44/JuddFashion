import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../services/auth';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './account.html',
  styleUrl: './account.scss',
})
export class Account {
  private authService = inject(Auth);

  completeString: string = "Sign In";

  email: string = '';
  username: string = '';
  password: string = '';
  confirmPassword: string = '';
  errorMessage: string = '';
  accountTypeDisplay: string = 'Account Sign-In';

  loading: boolean = false; 
  signInSelected: boolean = false;
  isSignedIn: boolean = false;

  savedEmail: string = '';
  savedDate: Date = new Date();
  savedUsername: string = '';

  ngOnInit() {
  this.authService.currentUser$.subscribe(user => {
    if (user) {
      this.isSignedIn = true;
      this.savedEmail = user.email;
      this.savedDate = new Date(user.createdAt);
      this.savedUsername = user.username;
    } else {
      this.isSignedIn = false;
    }
  });
}

  ChangeRegisterType(isRegister: boolean) {
    this.signInSelected = !isRegister;
    this.password = '';
    this.confirmPassword = '';
    if (isRegister) { this.completeString = "Sign Up"; this.accountTypeDisplay = "Account Creation"; } else { this.completeString = "Log In"; this.accountTypeDisplay = "Account Sign-In"; }
  }

  OnLogin() {
    this.loading = true;
    this.errorMessage = '';

    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        console.log('Login Successful!', response);
      },
      error: (error) => {
        console.error('Login failed:', error);
        this.errorMessage = error.error?.message || 'Invalid email or password';
        this.loading = false;
      }
    });



  }

 
 OnRegister() {
    if (this.password !== this.confirmPassword) {
      this.errorMessage = 'Passwords do not match';
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.authService.register(this.username, this.email, this.password).subscribe({
      next: (response) => {
        console.log('Registration successful!', response);
      },
      error: (error) => {
        console.error('Registration failed!', error);
        this.errorMessage = error.error?.message || 'Registration failed. Please try again.';
        this.loading = false;
      }
    })
  }


Logout() {
  this.authService.logout();
}


}
