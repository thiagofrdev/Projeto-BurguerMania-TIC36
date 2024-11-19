import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CardComponent } from "../../components/card/card.component";
import { BotaoComponent } from "../../components/botao/botao.component";

@Component({
  selector: 'app-cardapio',
  standalone: true,
  imports: [CommonModule, RouterModule, CardComponent, BotaoComponent],
  templateUrl: './cardapio.component.html',
  styleUrl: './cardapio.component.css'
})
export class CardapioComponent {
  categorias: string[] = ['X-Vegan', 'X-Fitness', 'X-Infarto']; // Lista de categorias
}
