import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSearchQueryDialogComponent } from './update-search-query-dialog.component';

describe('UpdateSearchQueryDialogComponent', () => {
  let component: UpdateSearchQueryDialogComponent;
  let fixture: ComponentFixture<UpdateSearchQueryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateSearchQueryDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateSearchQueryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
