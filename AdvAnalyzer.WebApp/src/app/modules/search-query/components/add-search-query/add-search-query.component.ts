import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchQuery } from '../../models/search-query.model';

@Component({
  selector: 'app-add-search-query',
  templateUrl: './add-search-query.component.html',
  styleUrls: ['./add-search-query.component.scss']
})
export class AddSearchQueryComponent implements OnInit {
  public frequencies: number[] = [1, 2, 3, 4, 5, 10, 30, 60, 120, 240];
  public formGroup: FormGroup = this.formBuilder.group({
    'name': [null, Validators.required],
    'url': [null, Validators.required],
    'refreshFrequencyInMinutes': [null, Validators.required],
  });

  constructor(private readonly formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  submit(data: SearchQuery): void {
    console.log(data);
  }
}
