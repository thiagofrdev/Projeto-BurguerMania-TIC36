import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  @Input() nome: string = "Teste"; // Propriedade para o nome da categoria
  @Input() descricao: string = "Descrição padrão"; // Propriedade para a descrição da categoria
  @Input() imagem: string = ""; // Propriedade para a URL da imagem
}
