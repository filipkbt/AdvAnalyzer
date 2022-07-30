import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchQueryListComponent } from './components/search-query-list/search-query-list.component';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { RouterModule, Routes } from '@angular/router';
import { SearchQueryContainerComponent } from './containers/search-query-container/search-query-container.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddSearchQueryComponent } from './components/add-search-query/add-search-query.component';
import { UpdateSearchQueryDialogComponent } from './components/update-search-query-dialog/update-search-query-dialog.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent, children: [
      { path: '', component: SearchQueryContainerComponent },
    ]
  }
];

@NgModule({
  declarations: [
    SearchQueryListComponent,
    SearchQueryContainerComponent,
    AddSearchQueryComponent,
    UpdateSearchQueryDialogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class SearchQueryModule { }
