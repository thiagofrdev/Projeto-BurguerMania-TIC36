import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Categoria } from '../../interfaces/categoria/categoria';
import { Product } from '../../interfaces/product/product';

@Injectable({
  providedIn: 'root'
})
export class HamburguerService {
  private apiUrl = 'http://localhost:5106/Product';

  constructor(private http: HttpClient) {}

  getProductByName(nome: string): Observable<Product> {
    const url = `${this.apiUrl}/${nome}`;
    return this.http.get<{ message: string; products: Product }>(url).pipe(map(response => response.products));
  }
}
