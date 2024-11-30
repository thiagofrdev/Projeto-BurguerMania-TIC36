import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CardComponent } from "../../components/card/card.component";
import { BotaoComponent } from "../../components/botao/botao.component";
import { RouterModule } from '@angular/router';
import { Product } from '../../interfaces/product/product';
import { ProdutoService } from '../../services/produto/produto.service';
import { CategoriaService } from '../../services/categoria/categoria.service';

@Component({
  selector: 'app-categoria',
  standalone: true,
  imports: [CommonModule, CardComponent, BotaoComponent, RouterModule],
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {
  produtos: Product[] = [];
  produtosFiltrados: Product[] = []; // Apenas os produtos da categoria
  categoriaNome: string = "";
  error: string | null = null;

  constructor(
    private produtoService: ProdutoService, 
    private categoriaService: CategoriaService, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // Captura o nome da categoria diretamente da URL
    this.categoriaNome = this.route.snapshot.paramMap.get('categoria') || "";

    if (this.categoriaNome) {
      this.produtoService.getAllProducts().subscribe({
        next: (data) => {
          this.produtos = data.products.filter(
            (produto) => produto.CategoryName === this.categoriaNome
          );
        },
        error: (err) => console.error("Erro ao buscar produtos:", err),
      });
    }
  }
}