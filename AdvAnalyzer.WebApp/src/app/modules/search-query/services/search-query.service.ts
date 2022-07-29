import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../../auth/services/auth.service';
import { SearchQuery } from '../models/search-query.model';

@Injectable({
  providedIn: 'root'
})
export class SearchQueryService {
  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAllByUserId(): Observable<SearchQuery[]> {
    return this.http.get<SearchQuery[]>(environment.apiUrl + 'searchquery/user/' + this.userId);
  }

  getById(searchQueryId: number): Observable<SearchQuery> {
    return this.http.get<SearchQuery>(environment.apiUrl + 'searchquery/' + searchQueryId);
  }

  create(searchQuery: SearchQuery): Observable<SearchQuery> {
    searchQuery.userId = this.userId;
    return this.http.post<SearchQuery>(environment.apiUrl + 'searchquery', searchQuery);
  }

  update(searchQuery: SearchQuery): Observable<SearchQuery> {
    searchQuery.userId = this.userId;
    return this.http.put<SearchQuery>(environment.apiUrl + 'searchquery', searchQuery);
  }

  delete(searchQueryId: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.apiUrl + 'searchquery/' + searchQueryId);
  }

}
