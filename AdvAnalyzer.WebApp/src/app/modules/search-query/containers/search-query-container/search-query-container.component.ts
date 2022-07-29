import { Component, OnInit, ViewChild } from '@angular/core';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { SearchQueryService } from '../../services/search-query.service';
import { finalize, take } from 'rxjs';
import { SearchQueryListComponent } from '../../components/search-query-list/search-query-list.component';

@Component({
  selector: 'app-search-query-container',
  templateUrl: './search-query-container.component.html',
  styleUrls: ['./search-query-container.component.scss']
})
export class SearchQueryContainerComponent implements OnInit {
  public isLoading = false;
  @ViewChild(SearchQueryListComponent) searchQueryListComponent!: SearchQueryListComponent;

  constructor(private readonly searchQueryService: SearchQueryService) { }

  ngOnInit(): void {
  }

  public loadData(pagedListQueryParams: PagedListQueryParams): void {
    this.isLoading = true;
    this.searchQueryService.getAllByUserId(pagedListQueryParams.pageNumber, pagedListQueryParams.pageSize ?? this.searchQueryListComponent.pageSize).pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.searchQueryListComponent.paginator.pageIndex = pagedListQueryParams.pageNumber;
        this.searchQueryListComponent.paginator.length = data.count;
      });
    })
  }
}