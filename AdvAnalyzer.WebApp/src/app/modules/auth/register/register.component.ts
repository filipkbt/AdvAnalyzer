import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/core/models/auth/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;
  model: Register = {
    userName: '',
    password: '',
    confirmPassword: '',
    email: '',
    phoneNumber: ''
  };

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      'userName': ['', [Validators.required]],
      'password': ['', [Validators.required]],
      'confirmPassword': ['', [Validators.required]],
      'email': ['', [Validators.required]],
      'phoneNumber': ['', [Validators.required]]
    })
  }

  submit() {
    this.model.userName = this.form.controls['userName'].value;
    this.model.password = this.form.controls['password'].value;
    this.model.confirmPassword = this.form.controls['confirmPassword'].value;
    this.model.email = this.form.controls['email'].value;
    this.model.phoneNumber = this.form.controls['phoneNumber'].value;

    //this.service.register(this.model).subscribe(() => this.router.navigate(['']));
  }
}
