import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { finalize, take } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = this.formBuilder.group({
    'email': [null, [
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
    'password': [null, [Validators.required, Validators.minLength(8)]]
  });
  isLoading = false;

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService, private toastrService: ToastrService) { }

  ngOnInit() {

  }

  onFormSubmit() {
    this.isLoading = true;
    this.authService.login(this.loginForm.getRawValue())
      .pipe(finalize(() => this.isLoading = false), take(1))
      .subscribe(res => {
        if (res.token) {
          this.authService.isAuthenticated = true;
          localStorage.setItem('token', res.token);
          localStorage.setItem('userId', res.userId);
          localStorage.setItem('email', res.email);
          this.router.navigate(['site/dashboard']);
        }
      }, (err) => {
        this.toastrService.error('Login failed','Error!');
        console.log(err);
      });
  }

  register() {
    this.router.navigate(['site/auth/register']);
  }
}

