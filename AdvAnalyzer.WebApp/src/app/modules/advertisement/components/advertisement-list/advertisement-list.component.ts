import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { Advertisement } from '../../models/advertisement.model';

@Component({
  selector: 'app-advertisement-list',
  templateUrl: './advertisement-list.component.html',
  styleUrls: ['./advertisement-list.component.scss']
})
export class AdvertisementListComponent implements OnInit {

  @Input() isLoading: boolean = false;

  @Output() goToAdvertisementClicked = new EventEmitter<string>();
  @Output() setIsFavoriteClicked = new EventEmitter<Advertisement>();
  @Output() refreshList = new EventEmitter<PagedListQueryParams>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  pageSizeOptions: number[] = [5, 10, 25, 100];
  pageSize = 10;
  currentPage = 0;
  displayedColumns: string[] = ['imgUrl', 'title', 'price', 'location', 'dateAdded', 'isFavorite'];
  dataSource: MatTableDataSource<Advertisement> = new MatTableDataSource();

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

  public goToAdvertisement(url: string): void {
    this.goToAdvertisementClicked.emit(url);
  }

  public setIsFavorite(event: any, advertisement: Advertisement): void {
    event.stopPropagation();
    this.setIsFavoriteClicked.emit(advertisement);
  }

  private loadData(): void {
    this.refreshList.emit({ pageNumber: this.currentPage, pageSize: this.pageSize });
  }

}
