import { TestBed } from '@angular/core/testing';

import { SearchQueryService } from './search-query.service';

describe('SearchQueryService', () => {
  let service: SearchQueryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchQueryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
