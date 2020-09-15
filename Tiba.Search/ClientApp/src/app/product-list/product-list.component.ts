import { Component , OnInit } from '@angular/core';
import {ActivatedRoute,Router} from '@angular/router';
import {GithubService} from '../Shared/github.service';
import {BookmarkService} from '../Shared/bookmark.service';
import {Product} from '../Shared/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  
})

export class ProductListComponent implements OnInit {
  products = null;
  loading: boolean;
  totalCount: number;
  model = new Product(0,'','','');
  constructor(private route: ActivatedRoute, private router: Router,
              private githubService: GithubService,private bookmarkService : BookmarkService) {
    this.products = null;
    this.loading = false;
  }

  ngOnInit(): void {
     this.githubService.searchOnGithub('tiba')
      .subscribe(res => {
        this.loading = false;
        this.products = res.items;
        this.totalCount = res.total_count;
      });
  }
  onSubmit() {
    this.githubService.searchOnGithub(this.model.FullName)
        .subscribe(res => {
          this.loading = false;
          this.products = res.items;
          this.totalCount = res.total_count;
        });
  }
/*
  getBookmarks(){
    this.bookmarkService.getBookmarks()
    .subscribe(res=>
      {
        this.loading = false;
        this.products = res.Items;
        this.totalCount = res.TotalCount;
      });
  }
*/
  addBookmark(item: Product){
    this.bookmarkService.saveBookmark(item)
    .subscribe(res=>
      {console.log('Saved',res)
      this.router.navigate(['/']);
    });
  }
}
