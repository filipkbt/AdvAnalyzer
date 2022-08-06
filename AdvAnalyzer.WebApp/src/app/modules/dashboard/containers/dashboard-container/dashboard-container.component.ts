import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-dashboard-container',
  templateUrl: './dashboard-container.component.html',
  styleUrls: ['./dashboard-container.component.scss']
})
export class DashboardContainerComponent implements OnInit {
  multi: any[] | null = null;

  // options
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Day';
  yAxisLabel: string = 'New Advetisements';
  timeline: boolean = true;

  isLoadingChart = false;

  constructor(private readonly dashboardService: DashboardService) { }

  ngOnInit(): void {
    this.isLoadingChart = true;
    this.dashboardService.getLineChartAdvertisementsByDateAdded().subscribe(x => {
      this.multi = x.chartData;
      this.isLoadingChart = false;
    })
  }
}