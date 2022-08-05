import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { AdvertisementListComponent } from './components/advertisement-list/advertisement-list.component';
import { AdvertisementListContainerComponent } from './containers/advertisement-list-container/advertisement-list-container.component';
import { AuthGuard } from 'src/app/core/guards/auth.guard';

const routes: Routes = [
  {
    path: 'search-query/:searchQueryId',
    canActivate: [AuthGuard],
    component: LayoutComponent, children: [
      { path: '', component: AdvertisementListContainerComponent },
    ]
  },
  {
    path: 'favorite',
    canActivate: [AuthGuard],
    component: LayoutComponent, children: [
      { path: '', component: AdvertisementListContainerComponent  },
    ]
  },
  {
    path: 'all',
    canActivate: [AuthGuard],
    component: LayoutComponent, children: [
      { path: '', component: AdvertisementListContainerComponent  },
    ]
  }
];

@NgModule({
  declarations: [
    AdvertisementListComponent,
    AdvertisementListContainerComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ], exports: [
    AdvertisementListComponent,
    AdvertisementListContainerComponent
  ]
})
export class AdvertisementModule { }
