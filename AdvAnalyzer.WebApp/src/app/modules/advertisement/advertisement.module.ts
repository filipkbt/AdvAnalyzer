import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertisementsListComponent } from './components/advertisements-list/advertisements-list.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
      path: '',
      component: AdvertisementsListComponent
  }
];

@NgModule({
  declarations: [
    AdvertisementsListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class AdvertisementModule { }
