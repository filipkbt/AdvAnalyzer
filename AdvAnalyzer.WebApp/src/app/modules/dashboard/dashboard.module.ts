import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardContainerComponent } from './containers/dashboard-container/dashboard-container.component';
import { AdvertisementModule } from '../advertisement/advertisement.module';
import { NotificationModule } from '../notification/notification.module';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: LayoutComponent, children: [
      { path: '', component: DashboardContainerComponent },
    ]
  }
];

@NgModule({
  declarations: [DashboardContainerComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
    AdvertisementModule,
    NotificationModule
  ]
})
export class DashboardModule { }
