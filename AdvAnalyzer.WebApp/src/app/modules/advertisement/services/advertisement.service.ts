import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/core/models/paged-list.models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  constructor(private http: HttpClient) { }

  getAllBySearchQueryId(searchQueryId: number, pageNumber: number, pageSize: number): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.get<PagedList>(environment.apiUrl + 'advertisement/search-query/' + searchQueryId, { params: params });
  }

  getAllFavoritesByUserId(userId: number, pageNumber: number, pageSize: number): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.get<PagedList>(environment.apiUrl + 'advertisement/favorite/' + userId, { params: params });
  }
}
