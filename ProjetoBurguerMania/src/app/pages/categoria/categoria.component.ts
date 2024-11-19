import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-categoria',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {
  categoria: string = '';
  hamburgueres: string[] = [];

  // Dados simulados
  produtosPorCategoria: { [key: string]: string[] } = {
    'X-Vegan': ['X-Alface', 'X-Tomate', 'X-Frutas'],
    'X-Fitness': ['X-Proteína', 'X-Integral', 'X-Avocado'],
    'X-Infarto': ['X-Bacon', 'X-Costela', 'X-Coração']
  };

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Pega o nome da categoria da URL
    this.route.params.subscribe(params => {
      this.categoria = params['categoria'];
      this.hamburgueres = this.produtosPorCategoria[this.categoria] || [];
    });
  }
}