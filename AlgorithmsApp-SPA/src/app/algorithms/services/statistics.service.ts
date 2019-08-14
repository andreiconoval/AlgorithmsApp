import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private http: HttpClient) { }
  configUrl = 'http://localhost:5000/api/Algorithm/GetStatistics';

  getStatistics() {
    return this.http.get<AlgStatistic[]>(this.configUrl);
  }

  convertStatisticsToDatasets(algStat: AlgStatistic[]): Array<Dataset> {
    const colors = ['blue', 'yellow', 'red', 'green', 'black'];
    let datasets: Array<Dataset> = [];

    for (let i = 0; i < algStat.length; i++) {
      let dataset = new Dataset();
      dataset.label = algStat[i].algName;
      dataset.fill = false;
      dataset.data = [];
      algStat[i].statistics.forEach((x) => {
        dataset.data.push(x.executedTime);
      });
      dataset.yAxisID = 'left-y-axis';
      dataset.borderColor = colors[i];
      datasets.push(dataset);
    }
 
    return datasets;
  }

}


export class Dataset {
  data: number[];
  label: string;
  borderColor: string;
  fill: boolean;
  yAxisID: string;
}


export class AlgStatistic {
  algId: number;
  algName: string;
  statistics: Statistics[];
}

class Statistics {
  id: number;
  mockLength: number;
  executedTime: number;
  date: Date;
}
