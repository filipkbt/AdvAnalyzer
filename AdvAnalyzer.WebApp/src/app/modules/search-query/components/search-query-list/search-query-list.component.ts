import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/modules/auth/services/auth.service';
import { SearchQueryService } from '../../services/search-query.service';

@Component({
  selector: 'app-search-query-list',
  templateUrl: './search-query-list.component.html',
  styleUrls: ['./search-query-list.component.scss']
})
export class SearchQueryListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'url','results','new', 'action'];

  constructor(private readonly searchQueryService: SearchQueryService) { }

  ngOnInit(): void {
    this.searchQueryService.getAllByUserId().subscribe(x => {
      console.log(x);
    })

    this.searchQueryService.getById(1).subscribe(x => {
      console.log(x);
    })
  }

}
