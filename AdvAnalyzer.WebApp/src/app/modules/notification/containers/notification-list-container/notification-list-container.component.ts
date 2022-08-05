import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
import { NotificationListComponent } from '../../components/notification-list/notification-list.component';
import { NotificationService } from '../../services/notification.service';
import { finalize, take } from 'rxjs';
import { Constants } from 'src/app/core/constants/constants';

@Component({
  selector: 'app-notification-list-container',
  templateUrl: './notification-list-container.component.html',
  styleUrls: ['./notification-list-container.component.scss']
})
export class NotificationListContainerComponent implements OnInit {

  public isLoading = false;
  @ViewChild(NotificationListComponent) searchQueryListComponent!: NotificationListComponent;
  @Input() displayPaginator = true;
  @Input() pageSize = 25;

  constructor(private readonly notificationService: NotificationService, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  public loadData(pagedListQueryParams?: PagedListQueryParams): void {
    this.isLoading = true;
    this.notificationService.getAllByUserId(pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage, pagedListQueryParams?.pageSize ?? this.searchQueryListComponent.pageSize).pipe(finalize(() => this.isLoading = false), take(1)).subscribe(data => {
      this.searchQueryListComponent.dataSource.data = data.data;
      setTimeout(() => {
        if(this.displayPaginator) {
          this.searchQueryListComponent.paginator.pageIndex = pagedListQueryParams?.pageNumber ?? this.searchQueryListComponent.currentPage;
          this.searchQueryListComponent.paginator.length = data.count;
        }
      });
    })
  }
}
