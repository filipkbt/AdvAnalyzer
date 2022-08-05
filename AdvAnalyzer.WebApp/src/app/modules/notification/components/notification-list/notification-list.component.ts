import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss']
})
export class NotificationListComponent implements OnInit {
  @Input() isLoading: boolean = false;
  @Input() displayPaginator = true;
  @Input() pageSize = 25;

  @Output() refreshList = new EventEmitter<PagedListQueryParams>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  pageSizeOptions: number[] = [5, 10, 25, 100];
  currentPage = 0;
  displayedColumns: string[] = ['dateAdded', 'message'];
  dataSource: MatTableDataSource<Notification> = new MatTableDataSource();

  constructor() { }

  ngOnInit(): void {
    this.loadData();
  }

  ngAfterViewInit(): void {
    if (this.displayPaginator)  this.dataSource.paginator = this.paginator;
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
