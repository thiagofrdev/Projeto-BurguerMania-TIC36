import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CardComponent } from "../../components/card/card.component";
import { BotaoComponent } from "../../components/botao/botao.component";
import { CategoriaService } from '../../services/categoria/categoria.service';
import { Categoria } from '../../interfaces/categoria/categoria';

@Component({
  selector: 'app-cardapio',
  standalone: true,
  imports: [CommonModule, RouterModule, CardComponent, BotaoComponent],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css'
})
export class CardapioComponent implements OnInit {
  categorias: Categoria[] = []; // Lista de categorias
  error: string | null = null;

   constructor(private categoriaService: CategoriaService) {}

   ngOnInit(): void {
    this.categoriaService.getAllCategories().subscribe({
      next: (data) => {
        this.categorias = data; // Atualiza a lista de categorias
        this.error = null;
      },
      error: (err) => {
        console.error('Erro ao carregar categorias:', err);
        this.error = 'Erro ao carregar categorias. Tente novamente mais tarde.';
      },
    });
  }
}
