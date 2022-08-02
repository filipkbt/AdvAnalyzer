import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdvertisementService } from '../../services/advertisement.service';
import { finalize, take } from 'rxjs';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { AdvertisementListComponent } from '../../components/advertisement-list/advertisement-list.component';

@Component({
  selector: 'app-advertisement-list-container',
  templateUrl: './advertisement-list-container.component.html',
  styleUrls: ['./advertisement-list-container.component.scss']
})
export class AdvertisementListContainerComponent implements OnInit {
  public isLoading = true;
  private searchQueryId: number = 0;

  @ViewChild(AdvertisementListComponent) searchQueryListComponent!: AdvertisementListComponent;

  constructor(private readonly advertisementService: AdvertisementService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.pipe(take(1)).subscribe(params => {
      this.searchQueryId = +params['searchQueryId'];
      this.loadData()
   });
  }

  public loadData(pagedListQueryParams?: PagedListQueryParams): void {
    this.isLoading = true;
    this.advertisementService.getAllBySearchQueryId(this.searchQueryId, pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent.pageSize).pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        this.searchQueryListComponent.paginator.pageIndex = pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage;
        this.searchQueryListComponent.paginator.length = data.count;
      });
    })
  }

  public goToAdvertisement(advertisementUrl: string): void {

  }

}
