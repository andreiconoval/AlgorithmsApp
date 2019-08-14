import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SortAlgService } from '../services/sort-alg.service';
import { StatisticsService, AlgStatistic, Dataset } from '../services/statistics.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MainComponent implements OnInit {

  constructor(private sortAlgService: SortAlgService, private statistics: StatisticsService) { }
  configUrl: number;
  algStatistics: AlgStatistic[];
  ngOnInit() {
  }

  showInsertAlgTime() {
    this.sortAlgService.getTimeForInsertAlg()
      .subscribe((data: number) => this.configUrl = data);
  }

}
