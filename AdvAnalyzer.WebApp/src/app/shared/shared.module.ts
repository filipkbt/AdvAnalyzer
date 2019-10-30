import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';

import { pages } from './pages';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [SidenavComponent, pages],
  imports: [
    CommonModule,
    AngularMaterialModule,
    CoreModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    AngularMaterialModule,
    CommonModule,
    CoreModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class SharedModule { }
