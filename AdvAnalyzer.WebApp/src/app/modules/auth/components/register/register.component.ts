import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup  = this.formBuilder.group({
    'email' : [null, Validators.required],
    'password' : [null, [Validators.required, Validators.minLength(8)]]
  });

  isLoadingResults = false;

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  onFormSubmit() {
    this.authService.register(this.registerForm.getRawValue())
      .subscribe(res => {
        this.router.navigate(['site/auth']);
      }, (err) => {
        console.log(err);
        alert(err.error);
      });
  }

  navigateBack(): void {
    this.router.navigate(['site/auth']);
  }

}
