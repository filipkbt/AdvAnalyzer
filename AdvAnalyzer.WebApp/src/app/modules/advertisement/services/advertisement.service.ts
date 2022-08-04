import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedList } from 'src/app/core/models/paged-list.models';
import { environment } from 'src/environments/environment';
import { AuthService } from '../../auth/services/auth.service';
import { Advertisement } from '../models/advertisement.model';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {
  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getAllBySearchQueryId(searchQueryId: number, pageNumber: number, pageSize: number, searchTerm: string): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    params = params.append('searchTerm', searchTerm);
    return this.http.get<PagedList>(environment.apiUrl + 'advertisement/search-query/' + searchQueryId, { params: params });
  }

  getAllFavoritesByUserId(pageNumber: number, pageSize: number, searchTerm: string): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    params = params.append('searchTerm', searchTerm);
    return this.http.get<PagedList>(environment.apiUrl + 'advertisement/favorite/' + this.userId, { params: params });
  }

  getAllByUserId(pageNumber: number, pageSize: number, searchTerm: string): Observable<PagedList> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    params = params.append('searchTerm', searchTerm);
    return this.http.get<PagedList>(environment.apiUrl + 'advertisement/all/' + this.userId, { params: params });
  }

  update(advertisement: Advertisement): Observable<Advertisement> {
    return this.http.put<Advertisement>(environment.apiUrl + 'advertisement', advertisement);
  }
}
