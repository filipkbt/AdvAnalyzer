import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatRipple } from '@angular/material/core';
import { Router } from '@angular/router';
import { interval, mergeMap, of } from 'rxjs';
import { AuthService } from 'src/app/modules/auth/services/auth.service';
import { NotificationService } from '../services/notification.service';
import { take } from 'rxjs';
import { Notification } from '../models/notification.model';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit, OnDestroy {
  public newNotificationsCount: number = 0;
  public notifications: Notification[] = [];
  private _mobileQueryListener: () => void;
  mobileQuery: MediaQueryList;

  @ViewChild(MatRipple) ripple!: MatRipple;

  constructor(private changeDetectorRef: ChangeDetectorRef, private media: MediaMatcher, public authService: AuthService, private router: Router, private readonly notificationService: NotificationService) {
    this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    // tslint:disable-next-line: deprecation
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit(): void {
    this.notificationService.getAllNotSeenByUserId().pipe(take(1)).subscribe(data => {
      this.newNotificationsCount = data.length;
      this.notifications = data;
      this.launchRipple();
    })

    interval(2 * 5 * 1000)
      .pipe(
        mergeMap(() => this.notificationService.getAllNotSeenByUserId())
      )
      .subscribe(data => {
        if (data.length !== this.newNotificationsCount) {
          this.newNotificationsCount = data.length;
          this.notifications = data;
          this.launchRipple();
        }
      })
  }

  ngOnDestroy(): void {
    // tslint:disable-next-line: deprecation
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  logout(): void {
    localStorage.removeItem('token')
    this.authService.isAuthenticated = false;
    this.router.navigate(['site/auth']);
  }

  launchRipple() {
    const rippleRef = this.ripple.launch({
      persistent: true,
      centered: true
    });

    // Fade out the ripple later.
    rippleRef.fadeOut();
  }
}
