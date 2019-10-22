import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { pages } from './pages';


@NgModule({
  declarations: [SidenavComponent, pages],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatCheckboxModule
  ]
})
export class SharedModule { }
