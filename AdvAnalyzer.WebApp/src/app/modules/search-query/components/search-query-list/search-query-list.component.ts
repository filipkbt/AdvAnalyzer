import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/modules/auth/services/auth.service';
import { SearchQueryService } from '../../services/search-query.service';

@Component({
  selector: 'app-search-query-list',
  templateUrl: './search-query-list.component.html',
  styleUrls: ['./search-query-list.component.scss']
})
export class SearchQueryListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'url','results','new', 'action'];

  constructor(private readonly searchQueryService: SearchQueryService, private readonly authService: AuthService) { }

  ngOnInit(): void {
    this.searchQueryService.getAll(this.authService.getUserId()).subscribe(x => {
      console.log(x);
    })
  }

}
