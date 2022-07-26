import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../core/models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  basesUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<IPagination>(this.basesUrl + 'products?pageSize=50');
  }
}
