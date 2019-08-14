import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Chart } from 'chart.js';
import { Dataset } from '../services/statistics.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LineChartComponent implements OnInit {
  @Input() datasets: Array<Dataset>;
  LineChart = [];

  constructor() { }

  ngOnInit() {

    this.initLineChart();

  }

  initLineChart() {

    this.LineChart = new Chart('lineChart', {
      type: 'line',
      data: {
        datasets: this.datasets
        ,
        labels: [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
          29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40]
      },
      options: {
        scales: {
          yAxes: [{
            id: 'left-y-axis',
            type: 'linear',
            position: 'left'
          }
          ]
        }
      }
    });
  }
}


