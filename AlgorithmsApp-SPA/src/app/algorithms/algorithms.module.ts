import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MainComponent } from './main/main.component';

import { SortAlgService } from './services/sort-alg.service';
import { SidebarComponent } from './sidebar/sidebar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LineChartComponent } from './line-chart/line-chart.component';

import { AlgorithmsRoutingModule } from './algorithms-routing.module';

@NgModule({
  declarations: [
    MainComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    DashboardComponent,
    LineChartComponent
  ],
  imports: [
    CommonModule,
    AlgorithmsRoutingModule
  ],
  providers: [SortAlgService],
  bootstrap: [MainComponent]
})
export class AlgorithmsModule { }
