import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Product } from '../../interfaces/product/product';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  //URL da API
  private apiUrl = 'http://localhost:5106/Product';

  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]>{
    return this.http
      .get<{ Message: string; products: Product[]}>(this.apiUrl)
      .pipe(map((response) => 
        response.products.map((product) => ({
          name_Product: product.name_Product,
          path_Image_Product: product.path_Image_Product,
          price_Product: product.price_Product,
          base_Description_Product: product.base_Description_Product,
          full_Description_Product: product.full_Description_Product,
        }))
      ))
  }
}