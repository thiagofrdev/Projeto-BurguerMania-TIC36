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

  getProductsByCategoryName(categoriaName: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}${categoriaName}`);
  }

  getAllProducts(): Observable<{ Message: string; products: Product[] }> {
    return this.http.get<{ Message: string; products: Product[] }>(this.apiUrl);
  }

  // Busca um produto pelo nome
  getProductByName(name: string): Observable<{ Message: string; products: Product[] }> {
    return this.http.get<{ Message: string; products: Product[] }>(this.apiUrl);
  }
}