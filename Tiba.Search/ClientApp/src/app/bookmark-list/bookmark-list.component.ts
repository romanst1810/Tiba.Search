import { Component , OnInit } from '@angular/core';
import {ActivatedRoute,Router} from '@angular/router';
import {BookmarkService} from '../Shared/bookmark.service';
import {Product} from '../Shared/product';

@Component({
  selector: 'app-bookmark-list',
  templateUrl: './bookmark-list.component.html',
  styleUrls: ['./bookmark-list.component.css']
})

export class BookmarkListComponent implements OnInit {
  products = null;
  loading: boolean;
  totalCount: number;
  model = new Product(0,'','','');
  constructor(private route: ActivatedRoute, private router: Router,
              private bookmarkService : BookmarkService) {
    this.products = null;
    this.loading = false;
  }

  ngOnInit(): void {
    this.bookmarkService.getBookmarks()
    .subscribe(res=>
      {
        this.loading = false;
        this.products = res.items;
        this.totalCount = res.total_count;
      });
  }
}
