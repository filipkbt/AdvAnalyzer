import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/modules/auth/services/auth.service';
import { SearchQuery } from '../../models/search-query.model';
import { SearchQueryService } from '../../services/search-query.service';
import { finalize, take } from 'rxjs';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
@Component({
  selector: 'app-search-query-list',
  templateUrl: './search-query-list.component.html',
  styleUrls: ['./search-query-list.component.scss']
})
export class SearchQueryListComponent implements OnInit {
  @Input() isLoading: boolean = false;

  @Output() refreshList = new EventEmitter<PagedListQueryParams>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  pageSizeOptions: number[] = [5, 10, 25, 100];
  pageSize = 5;
  currentPage = 0;
  displayedColumns: string[] = ['name', 'url', 'results', 'new', 'action'];
  dataSource: MatTableDataSource<SearchQuery> = new MatTableDataSource();

  constructor() { }

  ngOnInit(): void {
    this.loadData();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  public pageChanged(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadData();
  }

  private loadData(): void {
    this.refreshList.emit({ pageNumber: this.currentPage, pageSize: this.pageSize });
  }
}
