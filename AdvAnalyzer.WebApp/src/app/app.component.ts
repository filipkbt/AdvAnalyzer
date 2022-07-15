import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './modules/auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AdvAnalyzer.WebApp';

  constructor(public authService: AuthService, private router: Router) {

  }

  logout(): void {
    localStorage.removeItem('token')
    this.authService.isAuthenticated = false;
    this.router.navigate(['site/auth']);
  }
}
