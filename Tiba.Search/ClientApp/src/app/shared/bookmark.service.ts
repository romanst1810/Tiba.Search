import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import {Product} from './product';
import {ProductPageResult} from './PageResult';

@Injectable({
  providedIn: 'root'
})
export class BookmarkService {
  private apiUrl = '/api/bookmark';
  private baseUrl = 'https://localhost:44301'
  constructor(private http: HttpClient) { }

  getBookmarks(): Observable<ProductPageResult> {
    const endPoint = `${this.baseUrl + this.apiUrl}`;
    return this.http.get<ProductPageResult>(endPoint);
  }

  saveBookmark(item: Product): Observable<any>{
    const endPoint = `${this.baseUrl + this.apiUrl}`;
    return this.http.post(endPoint, item);
  }
 
}