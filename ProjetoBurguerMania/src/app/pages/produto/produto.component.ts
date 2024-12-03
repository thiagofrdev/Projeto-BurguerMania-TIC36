import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BotaoComponent } from "../../components/botao/botao.component";
import { RouterModule } from '@angular/router';
import { Product } from '../../interfaces/product/product';
import { HamburguerService } from '../../services/hamburguer/hamburguer.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-produto',
  standalone: true,
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css'],
  imports: [BotaoComponent, RouterModule, CommonModule]
})
export class ProdutoComponent implements OnInit {
  produto: Product | undefined; // Produto específico
  error: string | null = null;

  constructor(
    private hamburguerService: HamburguerService, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // Capturar o nome do produto pela rota
    const nomeProduto = this.route.snapshot.paramMap.get('produto');

    if (nomeProduto) {
      // Buscar o produto pelo nome no serviço
      this.hamburguerService.getProductByName(nomeProduto).subscribe({
        next: (data) => {
          this.produto = data; // Salva o produto retornado
        },
        error: (err) => {
          console.error('Erro ao buscar produto:', err);
          this.error = 'Produto não encontrado ou houve um erro no servidor.';
        }
      });
    } else {
      this.error = "Produto não especificado.";
    }
  }
}