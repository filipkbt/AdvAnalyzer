import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { finalize, take } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = this.formBuilder.group({
    'email': [null, Validators.required],
    'password': [null, Validators.required]
  });
  isLoadingResults = false;

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit() {

  }

  onFormSubmit() {
    this.isLoadingResults = true;
    this.authService.login(this.loginForm.getRawValue())
      .pipe(finalize(() => this.isLoadingResults = false), take(1))
      .subscribe(res => {
        if (res.token) {
          this.authService.isAuthenticated = true;
          localStorage.setItem('token', res.token);
          localStorage.setItem('userId', res.userId);
          localStorage.setItem('email', res.email);
          this.router.navigate(['site/advertisement']);
        }
      }, (err) => {
        console.log(err);
      });
  }

  register() {
    this.router.navigate(['site/auth/register']);
  }
}

