import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import {Product} from './product';
import {ProductPageResult} from './PageResult';

@Injectable({
  providedIn: 'root'
})
export class GithubService {
  private apiUrl = '/api/github/search';
  private baseUrl = 'https://localhost:44301';
  constructor(private http: HttpClient) { }

  searchOnGithub(text: string): Observable<ProductPageResult> {
    const endPoint = `${this.apiUrl}/${text}`;
    return this.http.get<ProductPageResult>(endPoint);
  }
 
}
