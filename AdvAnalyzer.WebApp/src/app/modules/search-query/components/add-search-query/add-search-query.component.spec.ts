import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSearchQueryComponent } from './add-search-query.component';

describe('AddSearchQueryComponent', () => {
  let component: AddSearchQueryComponent;
  let fixture: ComponentFixture<AddSearchQueryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSearchQueryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddSearchQueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
