import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/core/models/auth/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  model: Login = {
    userName: '',
    password: ''
  };

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      'userName': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
  }

  submit() {
    this.model.userName = this.form.controls['userName'].value;
    this.model.password = this.form.controls['password'].value;
  }

}
