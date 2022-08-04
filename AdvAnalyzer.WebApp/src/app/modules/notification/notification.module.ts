import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationListComponent } from './components/notification-list/notification-list.component';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { NotificationListContainerComponent } from './containers/notification-list-container/notification-list-container.component';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: '',
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
  ]
})
export class NotificationModule { }
