import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchQuery } from '../../models/search-query.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-update-search-query-dialog',
  templateUrl: './update-search-query-dialog.component.html',
  styleUrls: ['./update-search-query-dialog.component.scss']
})
export class UpdateSearchQueryDialogComponent implements OnInit {
  public frequencies: number[] = [3, 5, 15, 30, 60];
  public formGroup: FormGroup = this.formBuilder.group({
    'id': [null],
    'name': [null, Validators.required],
    'url': [null, [Validators.required, Validators.pattern('(https?://)?www.olx\\.pl(.*)')]],
    'refreshFrequencyInMinutes': [null, Validators.required],
    'sendEmailNotifications': [false, Validators.required]
  });

  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<UpdateSearchQueryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: SearchQuery) {
    this.formGroup = this.formBuilder.group({
      'id': [data.id],
      'name': [data.name, Validators.required],
      'url': [data.url, [Validators.required, Validators.pattern('(https?://)?www.olx\\.pl(.*)')]],
      'refreshFrequencyInMinutes': [data.refreshFrequencyInMinutes, Validators.required],
      'sendEmailNotifications': [data.sendEmailNotifications, Validators.required]
    });
  }

  ngOnInit(): void {

  }


  save() {
    this.dialogRef.close(this.formGroup?.getRawValue());
  }

  close() {
    this.dialogRef.close();
  }
}
