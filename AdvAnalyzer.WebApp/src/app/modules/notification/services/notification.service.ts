import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/core/models/paged-list.models';
import { environment } from 'src/environments/environment';
import { AuthService } from '../../auth/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAllByUserId(pageNumber: number, pageSize: number): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.get<PagedList>(environment.apiUrl + 'notification/user/' + this.userId + '/all', { params: params });
  }
}


