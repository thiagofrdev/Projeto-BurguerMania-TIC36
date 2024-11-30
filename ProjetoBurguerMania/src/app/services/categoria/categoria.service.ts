import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Categoria } from '../../interfaces/categoria/categoria';


@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  private apiUrl = 'http://localhost:5106/Categories';

  constructor(private http: HttpClient) {}

  getAllCategories(): Observable<Categoria[]> {
    return this.http
      .get<{ Message: string; categories: Categoria[] }>(this.apiUrl)
      .pipe(
        map((response) =>
          response.categories.map((categoria) => ({
            name_Category: categoria.name_Category,
            description_Category: categoria.description_Category || 'Descrição não disponível',
            path_Image_Category: categoria.path_Image_Category,
          }))
        )
      );
  }

  //Método para obter o nome da categoria pelo ID
  getCategoryByName(name: string): Observable<Categoria> {
    return this.http.get<Categoria>(`${this.apiUrl}/${name}`);
  }
}
