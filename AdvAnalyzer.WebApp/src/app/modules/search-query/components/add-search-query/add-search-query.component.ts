import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchQuery } from '../../models/search-query.model';
import { SearchQueryService } from '../../services/search-query.service';
import { finalize, take } from 'rxjs';
import { PagedListQueryParams } from 'src/app/core/models/paged-list-query-params.model';
@Component({
  selector: 'app-add-search-query',
  templateUrl: './add-search-query.component.html',
  styleUrls: ['./add-search-query.component.scss']
})
export class AddSearchQueryComponent implements OnInit {
  @Output() refreshList = new EventEmitter<PagedListQueryParams>();

  public frequencies: number[] = [3, 5, 15, 30, 60];
  public formGroup: FormGroup = this.formBuilder.group({
    'name': [null, Validators.required],
    'url': [null, [Validators.required, Validators.pattern('(https?://)?www.olx\\.pl(.*)created_at:desc(.*)$')]],
    'refreshFrequencyInMinutes': [null, Validators.required],
    'sendEmailNotifications': [false, Validators.required]
  });

  constructor(private readonly formBuilder: FormBuilder, private readonly searchQueryService: SearchQueryService) { }

  ngOnInit(): void {
  }

  submit(data: SearchQuery): void {
    this.searchQueryService.create(data).pipe(take(1)).subscribe(x => {
      this.formGroup.reset();
      this.refreshList.emit({ pageNumber: 0 });
    })
  }
}
