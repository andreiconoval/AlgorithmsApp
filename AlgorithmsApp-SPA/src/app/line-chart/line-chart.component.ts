import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LineChartComponent implements OnInit {
  LineChart = [];

  constructor() { }

  ngOnInit() {
    this.LineChart = new Chart('lineChart', {
      type: 'line',
      data: {
        datasets: [{
          data: [4.1, 0.6, 1.4, 1.0, 2.5, 2],
          label: 'Alg1 dataset',
          borderColor: 'red',
          fill: false,

          // This binds the dataset to the left y axis
          yAxisID: 'left-y-axis'
        }, {
          data: [0.1, 0.5, 1.0, 2.0, 1.5, 0],
          label: 'Alg2 dataset',
          borderColor: 'blue',
          fill: false,

          // This binds the dataset to the right y axis
          yAxisID: 'left-y-axis'
        }, {
          data: [2.1, 0.7, 1.1, 2.0, 1.5, 1],
          label: 'ALg3 dataset',
          borderColor: 'yellow',
          fill: false,

          // This binds the dataset to the right y axis
          yAxisID: 'left-y-axis'
        }],
        labels: [10, 1000, 1500, 30000, 50000, 100000]
      },
      options: {
        scales: {
          yAxes: [{
            id: 'left-y-axis',
            type: 'linear',
            position: 'left'
          }, //{
          //   id: 'right-y-axis',
          //   type: 'linear',
          //   position: 'right'
          // }
        ]
        }
      }
    });
  }
}
