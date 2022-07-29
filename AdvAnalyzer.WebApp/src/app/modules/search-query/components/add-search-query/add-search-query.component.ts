import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchQuery } from '../../models/search-query.model';
import { SearchQueryService } from '../../services/search-query.service';

@Component({
  selector: 'app-add-search-query',
  templateUrl: './add-search-query.component.html',
  styleUrls: ['./add-search-query.component.scss']
})
export class AddSearchQueryComponent implements OnInit {
  public frequencies: number[] = [1, 2, 3, 4, 5, 10, 30, 60, 120, 240];
  public formGroup: FormGroup = this.formBuilder.group({
    'name': [null, Validators.required],
    'url': [null, [Validators.required, Validators.pattern('(https?://)?www.olx\\.pl(.*)')]],
    'refreshFrequencyInMinutes': [null, Validators.required],
  });

  constructor(private readonly formBuilder: FormBuilder, private readonly searchQueryService: SearchQueryService) { }

  ngOnInit(): void {
  }

  submit(data: SearchQuery): void {
    this.searchQueryService.create(data).subscribe(x=> {
      console.log(x);
    })
  }
}
