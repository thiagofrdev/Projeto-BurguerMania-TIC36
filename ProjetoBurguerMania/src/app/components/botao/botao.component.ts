import { Component, input, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-botao',
  standalone: true,
  imports: [CommonModule, MatButtonModule],
  templateUrl: './botao.component.html',
  styleUrl: './botao.component.css'
})

//Classe com propriedades que podem ser modificadas dinamicamente
export class BotaoComponent {
  @Input() texto: string = 'Botão';
  @Input() tamanhoFonte: string = '1';
  @Input() valor: string = 'Teste'; // Texto padrão
  @Input() cor: string = 'blue'; // Cor padrão
  @Input() corFonte: string = 'black';
  @Input() largura: string = '';
}
