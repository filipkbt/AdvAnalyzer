import { Component, EventEmitter, Input, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { debounce, Subscription, debounceTime } from 'rxjs';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { Advertisement } from '../../models/advertisement.model';

@Component({
  selector: 'app-advertisement-list',
  templateUrl: './advertisement-list.component.html',
  styleUrls: ['./advertisement-list.component.scss']
})
export class AdvertisementListComponent implements OnInit, OnDestroy {
  @Input() isLoading: boolean = false;
  @Input() displayPaginator = true;
  @Input() pageSize = 25;

  @Output() goToAdvertisementClicked = new EventEmitter<string>();
  @Output() setIsFavoriteClicked = new EventEmitter<Advertisement>();
  @Output() refreshList = new EventEmitter<PagedListQueryParams>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  pageSizeOptions: number[] = [5, 10, 25, 100];
  currentPage = 0;
  displayedColumns: string[] = ['imgUrl', 'title', 'price', 'location', 'dateAdded', 'isFavorite'];
  dataSource: MatTableDataSource<Advertisement> = new MatTableDataSource();
  searchForm = new FormGroup({
    searchTerm: new FormControl('')
  })
  private searchSubscription: Subscription | undefined;
  private searchTerm = '';

  constructor() { }

  ngOnInit(): void {
    this.loadData();
  }

  ngOnDestroy(): void {
    if (this.searchSubscription) this.searchSubscription.unsubscribe();
  }

  ngAfterViewInit(): void {
    if (this.displayPaginator) this.dataSource.paginator = this.paginator;

    this.searchSubscription = this.searchForm.get('searchTerm')?.valueChanges.pipe(debounceTime(300)).subscribe(term => {
      if (term) {
        this.currentPage = 0;
        this.searchTerm = term;
        this.loadData();
      }
    })
  }

  public pageChanged(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadData();
  }

  public goToAdvertisement(url: string): void {
    this.goToAdvertisementClicked.emit(url);
  }

  public setIsFavorite(event: any, advertisement: Advertisement): void {
    event.stopPropagation();
    this.setIsFavoriteClicked.emit(advertisement);
  }

  private loadData(): void {
    this.refreshList.emit({ pageNumber: this.currentPage, pageSize: this.pageSize, searchTerm: this.searchTerm ?? '' });
  }

}
