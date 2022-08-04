import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list'
import { MatMenuModule } from '@angular/material/menu'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatDialogModule } from '@angular/material/dialog'
import { MatSelectModule } from '@angular/material/select'
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatBadgeModule } from '@angular/material/badge';
import {MatRipple, MatRippleModule} from '@angular/material/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ShowIfTruncatedDirective } from './directives/show-if-truncated.directive';

const additionalModules = [
  MatInputModule,
  MatPaginatorModule,
  MatProgressSpinnerModule,
  MatSortModule,
  MatTableModule,
  MatIconModule,
  MatButtonModule,
  MatCardModule,
  MatFormFieldModule,
  MatSidenavModule,
  MatListModule,
  MatMenuModule,
  MatToolbarModule,
  MatProgressBarModule,
  FormsModule,
  ReactiveFormsModule,
  HttpClientModule,
  FlexLayoutModule,
  MatDialogModule,
  MatSelectModule,
  MatCheckboxModule,
  MatTooltipModule,
  MatBadgeModule,
  MatRippleModule
]

@NgModule({
  declarations: [
    LayoutComponent,
    ConfirmationDialogComponent,
    ShowIfTruncatedDirective
  ],
  imports: [
    CommonModule,
    additionalModules,
    RouterModule

  ], exports: [additionalModules, ConfirmationDialogComponent]
})
export class SharedModule { }
