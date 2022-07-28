import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-query-list',
  templateUrl: './search-query-list.component.html',
  styleUrls: ['./search-query-list.component.scss']
})
export class SearchQueryListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'url','results','new', 'action'];

  constructor() { }

  ngOnInit(): void {
  }

}
