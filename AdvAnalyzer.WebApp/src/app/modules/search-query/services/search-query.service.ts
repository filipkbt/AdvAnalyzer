import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SearchQuery } from '../models/search-query.model';

@Injectable({
  providedIn: 'root'
})
export class SearchQueryService {

  constructor(private http: HttpClient) { }

  getAllByUserId(userId: number): Observable<SearchQuery[]> {
    return this.http.get<any>(environment.apiUrl + 'searchquery/user/' + userId);
  }

  getById(searchQueryId: number): Observable<SearchQuery> {
    return this.http.get<any>(environment.apiUrl + 'searchquery/' + searchQueryId);
  }

}
