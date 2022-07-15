import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {

  apiUrl = 'https://localhost:44309/api/auth/';

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl + 'book')
      .pipe(
        tap(_ => this.log('fetched books')),
        catchError(this.handleError('getBooks', []))
      );
  }
}
