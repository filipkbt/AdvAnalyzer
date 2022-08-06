import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../../auth/services/auth.service';
import { ChartData, ChartSingleData } from '../models/chart-single-data.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private userId: number = this.authService.getUserId();

  constructor(private http: HttpClient, private readonly authService: AuthService) { }

  getLineChartAdvertisementsByDateAdded(): Observable<ChartData> {
    let params = new HttpParams();
    return this.http.get<ChartData>(environment.apiUrl + 'dashboard/chart/advertisements-by-date-added/' + this.userId, { params: params });
  }
}
