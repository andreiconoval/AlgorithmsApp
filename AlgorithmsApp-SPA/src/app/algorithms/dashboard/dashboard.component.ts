import { Component, OnInit } from '@angular/core';
import { StatisticsService, AlgStatistic, Dataset } from '../services/statistics.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  algStatistics: AlgStatistic[];
  datasets: Array<Dataset>;
  
  constructor(private statistics: StatisticsService) { }

  ngOnInit() {
    this.showStatistics();
  }

  showStatistics() {
    this.statistics.getStatistics()
      .subscribe((data: AlgStatistic[]) => {
        this.algStatistics = data;
        this.datasets = this.statistics.convertStatisticsToDatasets(this.algStatistics);
      });
  }

}
