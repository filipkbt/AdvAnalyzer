import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/modules/auth/services/auth.service';
import { environment } from 'src/environments/environment';
import { Notification } from '../models/notification.model';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAllNotSeenByUserId(): Observable<Notification[]> {
    return this.http.get<Notification[]>(environment.apiUrl + 'notification/user/' + this.userId + '/not-seen');
  }

  markAllNotificationAsSeenByUserId(): Observable<Notification[]>{
    return this.http.get<Notification[]>(environment.apiUrl + 'notification/user/' + this.userId + '/mark-as-seen');
  }
}
