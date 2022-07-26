import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchQueryListComponent } from './components/search-query-list/search-query-list.component';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent, children: [
      { path: '', component: SearchQueryListComponent },
    ]
  }
];

@NgModule({
  declarations: [
    SearchQueryListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class SearchQueryModule { }
