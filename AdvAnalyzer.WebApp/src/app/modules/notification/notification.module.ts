import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationListComponent } from './components/notification-list/notification-list.component';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { NotificationListContainerComponent } from './containers/notification-list-container/notification-list-container.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'all',
    canActivate: [AuthGuard],
    component: LayoutComponent, children: [
      { path: '', component: NotificationListContainerComponent },
    ]
  }
];

@NgModule({
  declarations: [
    NotificationListComponent,
    NotificationListContainerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ], exports: [
    NotificationListComponent,
    NotificationListContainerComponent
  ]
})
export class NotificationModule { }
