import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../../auth/services/auth.service';
import { SearchQuery } from '../models/search-query.model';

@Injectable({
  providedIn: 'root'
})
export class SearchQueryService {

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAll(userId: number): Observable<SearchQuery> {
    const params = new HttpParams().append('userId', this.authService.getUserId());

    return this.http.get<any>(environment.apiUrl + 'searchquery', { params: params });
  }

}
