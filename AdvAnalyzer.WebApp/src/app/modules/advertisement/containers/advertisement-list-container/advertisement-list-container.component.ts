import { Component, OnDestroy, OnInit, ViewChild, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementService } from '../../services/advertisement.service';
import { finalize, Subscription, take } from 'rxjs';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { AdvertisementListComponent } from '../../components/advertisement-list/advertisement-list.component';
import { Advertisement } from '../../models/advertisement.model';
import { ToastrService } from 'ngx-toastr';
import { Constants } from 'src/app/core/constants/constants';
import { FormControl, FormGroup } from '@angular/forms';
import { PagedList } from 'src/app/core/models/paged-list.models';

@Component({
  selector: 'app-advertisement-list-container',
  templateUrl: './advertisement-list-container.component.html',
  styleUrls: ['./advertisement-list-container.component.scss']
})
export class AdvertisementListContainerComponent implements OnInit {
  public isLoading = true;
  private searchQueryId: number = 0;
  @Input() displayPaginator = true;
  @Input() pageSize = 25;

  @ViewChild(AdvertisementListComponent) searchQueryListComponent!: AdvertisementListComponent;

  constructor(private readonly router: Router, private readonly advertisementService: AdvertisementService, private route: ActivatedRoute, private readonly toastr: ToastrService) { }

  ngOnInit(): void {

  }

  public loadData(pagedListQueryParams?: PagedListQueryParams): void {
    this.isLoading = true;
    if (this.router.url.includes('/site/advertisement/all') || this.router.url.includes('/site/dashboard')) {
      this.getAllByUserId();
    }
    else if (this.router.url.includes('/site/advertisement/favorite')) {
      this.getAllFavoritesByUserId(pagedListQueryParams);
    }
    else {
      this.route.params.pipe(take(1)).subscribe(params => {
        this.searchQueryId = params['searchQueryId'];
      });
      this.getAllBySearchQueryId(pagedListQueryParams);
    }
  }

  public getAllBySearchQueryId(pagedListQueryParams?: PagedListQueryParams): void {
    this.advertisementService.getAllBySearchQueryId(this.searchQueryId, pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent?.currentPage ?? 0, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent?.pageSize ?? Constants.DEFAULT_PAGE_SIZE, pagedListQueryParams?.searchTerm ?? '').pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.handlePaginatorUpdate(pagedListQueryParams, data);
      });
    })
  }

  public getAllFavoritesByUserId(pagedListQueryParams?: PagedListQueryParams): void {
    this.advertisementService.getAllFavoritesByUserId(pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent?.currentPage ?? 0, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent?.pageSize ?? Constants.DEFAULT_PAGE_SIZE, pagedListQueryParams?.searchTerm ?? '').pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.handlePaginatorUpdate(pagedListQueryParams, data);
      });
    })
  }

  public getAllByUserId(pagedListQueryParams?: PagedListQueryParams): void {
    this.advertisementService.getAllByUserId(pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent?.currentPage ?? 0, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent?.pageSize ?? Constants.DEFAULT_PAGE_SIZE, pagedListQueryParams?.searchTerm ?? '').pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.handlePaginatorUpdate(pagedListQueryParams, data);
      });
    })
  }

  public goToAdvertisement(advertisementUrl: string): void {
    if (!advertisementUrl.includes("https://www.")) {
      advertisementUrl = 'https://www.olx.pl' + advertisementUrl;
    }
    window.open(advertisementUrl, "_blank");
  }

  public setIsFavorite(advertisement: Advertisement): void {
    advertisement.isFavorite = !advertisement.isFavorite;
    this.advertisementService.update(advertisement).pipe(take(1)).subscribe();
  }

  private handlePaginatorUpdate(pagedListQueryParams: PagedListQueryParams | undefined, data: PagedList): void {
    if (this.displayPaginator) {
      this.searchQueryListComponent.paginator.pageIndex = pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent?.currentPage;
      this.searchQueryListComponent.paginator.length = data.count;
    }
  }
}
