import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SortAlgService } from '../services/sort-alg.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MainComponent implements OnInit {

  constructor(private sortAlgService: SortAlgService) { }
  configUrl: number;
  ngOnInit() {
    this.showInsertAlgTime();
  }

  showInsertAlgTime() {
    this.sortAlgService.getTimeForInsertAlg()
      .subscribe((data: number) => this.configUrl = data);
  }

}
