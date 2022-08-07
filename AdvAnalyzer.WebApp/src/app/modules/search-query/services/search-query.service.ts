import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/core/models/paged-list.models';
import { environment } from 'src/environments/environment';
import { Advertisement } from '../../advertisement/models/advertisement.model';
import { AuthService } from '../../auth/services/auth.service';
import { SearchQuery } from '../models/search-query.model';

@Injectable({
  providedIn: 'root'
})
export class SearchQueryService {
  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAllByUserId(pageNumber: number, pageSize: number): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.get<PagedList>(environment.apiUrl + 'searchquery/user/' + this.userId, { params: params });
  }

  getById(searchQueryId: number): Observable<SearchQuery> {
    return this.http.get<SearchQuery>(environment.apiUrl + 'searchquery/' + searchQueryId);
  }

  create(searchQuery: SearchQuery): Observable<SearchQuery> {
    searchQuery.userId = this.userId;
    return this.http.post<SearchQuery>(environment.apiUrl + 'searchquery', searchQuery);
  }

  markSearchQueryAdvertisementsAsSeen(searchQueryId: number): Observable<Advertisement[]> {
    return this.http.post<Advertisement[]>(environment.apiUrl + 'searchquery/' + searchQueryId + '/mark-advertisements-as-seen', {});
  }

  update(searchQuery: SearchQuery): Observable<SearchQuery> {
    searchQuery.userId = this.userId;
    return this.http.put<SearchQuery>(environment.apiUrl + 'searchquery', searchQuery);
  }

  delete(searchQueryId: number): Observable<boolean> {
    return this.http.delete<boolean>(environment.apiUrl + 'searchquery/' + searchQueryId);
  }

}
