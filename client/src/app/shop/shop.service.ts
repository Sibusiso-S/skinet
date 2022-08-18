import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBrand } from '../core/models/brand';
import { IPagination } from '../core/models/pagination';
import { IType } from '../core/models/productType';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  basesUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(brandId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }

    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http
      .get<IPagination>(this.basesUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(map((response) => response.body));
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.basesUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.basesUrl + 'products/types');
  }
}
