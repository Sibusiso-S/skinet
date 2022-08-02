import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../core/models/brand';
import { IPagination } from '../core/models/pagination';
import { IType } from '../core/models/productType';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  basesUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<IPagination>(this.basesUrl + 'products?pageSize=50');
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.basesUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.basesUrl + 'products/types');
  }
}
