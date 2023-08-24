import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { FullProduct } from '../types/Product/full-product-dto';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ProductAdd } from '../types/Product/product-add';
import { FullProductCardDto } from '../_models/product/FullProductCardDto';
import { productUpdateDto } from '../types/Product/product-update-dto';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  productToAdd: ProductAdd = new ProductAdd();

  constructor(private configService: ConfigService, private http: HttpClient) {}

  getProduct(productId: number): Observable<FullProduct> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<FullProduct>(`${baseUrl}Products/${productId}`);
  }

  getAll(
    searchString: string,
    cat: string[],
    restaurant: string[],
    prices: Number[]
  ) {
    let baseUrl: string = this.configService.getBaseApiUrl();
    console.log(
      `${baseUrl}Products?${cat
        .map((value) => `FilterTags=${value}`)
        .join('&')}&${restaurant
        .map((value) => `FilterRestaurants=${value}`)
        .join('&')}&${prices
        .map((value) => `FilterPrices=${value}`)
        .join('&')}&query=${searchString}`
    );
    return this.http.get<FullProductCardDto[]>(
      `${baseUrl}Products?${cat
        .map((value) => `FilterTags=${value}`)
        .join('&')}&${restaurant
        .map((value) => `FilterRestaurants=${value}`)
        .join('&')}&${prices
        .map((value) => `FilterPrices=${value}`)
        .join('&')}&word=${searchString}`
    );
  }

  getAllTags() {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<string[]>(`${baseUrl}Products/Tags`);
  }

  getPriceBounds() {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.get<number[]>(`${baseUrl}Products/PriceBounds`);
  }
  AddProduct(): Observable<number> {
    let baseUrl: string = this.configService.getBaseApiUrl();
    return this.http.post<number>(`${baseUrl}products`, this.productToAdd);
  }
  UpdateProduct(product: productUpdateDto): Observable<productUpdateDto> {
    let apiUrl: string = this.configService.getBaseApiUrl() + 'Products';
    return this.http.put<productUpdateDto>(apiUrl, product);
  }
}
