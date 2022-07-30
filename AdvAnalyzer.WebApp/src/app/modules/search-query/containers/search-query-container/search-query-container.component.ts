import { Component, OnInit, ViewChild } from '@angular/core';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { SearchQueryService } from '../../services/search-query.service';
import { finalize, take } from 'rxjs';
import { SearchQueryListComponent } from '../../components/search-query-list/search-query-list.component';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/confirmation-dialog/confirmation-dialog.component';
import { ConfirmationDialogModel } from 'src/app/shared/models/confirm-dialog.model';

@Component({
  selector: 'app-search-query-container',
  templateUrl: './search-query-container.component.html',
  styleUrls: ['./search-query-container.component.scss']
})
export class SearchQueryContainerComponent implements OnInit {
  public isLoading = false;
  @ViewChild(SearchQueryListComponent) searchQueryListComponent!: SearchQueryListComponent;

  constructor(private readonly searchQueryService: SearchQueryService, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  public loadData(pagedListQueryParams?: PagedListQueryParams): void {
    this.isLoading = true;
    this.searchQueryService.getAllByUserId(pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent.pageSize).pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.searchQueryListComponent.paginator.pageIndex = pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage;
        this.searchQueryListComponent.paginator.length = data.count;
      });
    })
  }

  public delete(id: number) {
    const message = `Are you sure you want to delete this Search Query?`;

    const dialogData: ConfirmationDialogModel = {title: "Confirm Action", message: message};

    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      maxWidth: "400px",
      data: dialogData
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult) {
        this.isLoading = true;
        this.searchQueryService.delete(id).pipe(finalize(() => this.isLoading = false), take(1)).subscribe(x => {
          this.loadData();
        })
      }
    });


  }
}