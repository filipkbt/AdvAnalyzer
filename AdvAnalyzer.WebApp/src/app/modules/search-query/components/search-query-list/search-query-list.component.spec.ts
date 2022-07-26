import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchQueryListComponent } from './search-query-list.component';

describe('SearchQueryListComponent', () => {
  let component: SearchQueryListComponent;
  let fixture: ComponentFixture<SearchQueryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchQueryListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchQueryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
