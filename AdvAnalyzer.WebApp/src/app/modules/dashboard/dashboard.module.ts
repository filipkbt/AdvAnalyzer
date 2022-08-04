import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardContainerComponent } from './containers/dashboard-container/dashboard-container.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent, children: [
      { path: '', component: DashboardContainerComponent },
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class DashboardModule { }
