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

    // Busca todos os produtos (ou você pode aplicar filtros se necessário)
    this.produtoService.getAllProducts().subscribe({
      next: (data) => {
        this.produtos = data;
      },
      error: (err) => {
        console.error("Erro ao buscar produtos:", err);
      }
    });
  }
}