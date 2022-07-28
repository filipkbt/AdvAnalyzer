import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchQueryContainerComponent } from './search-query-container.component';

describe('SearchQueryContainerComponent', () => {
  let component: SearchQueryContainerComponent;
  let fixture: ComponentFixture<SearchQueryContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchQueryContainerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchQueryContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
