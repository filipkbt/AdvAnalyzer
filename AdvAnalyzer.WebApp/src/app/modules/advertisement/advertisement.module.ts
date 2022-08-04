import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { AdvertisementListComponent } from './components/advertisement-list/advertisement-list.component';
import { AdvertisementListContainerComponent } from './containers/advertisement-list-container/advertisement-list-container.component';

const routes: Routes = [
  {
    path: 'search-query/:searchQueryId',
    component: LayoutComponent, children: [
      { path: '', component: AdvertisementListContainerComponent },
    ]
  },
  {
    path: 'favorite',
    component: LayoutComponent, children: [
      { path: '', component: AdvertisementListContainerComponent  },
    ]
  },
  {
    path: 'all',
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
  ]
})
export class AdvertisementModule { }
