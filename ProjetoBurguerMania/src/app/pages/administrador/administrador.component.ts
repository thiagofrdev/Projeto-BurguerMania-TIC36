import { Component } from '@angular/core';
import { BotaoComponent } from "../../components/botao/botao.component";
import { CardComponent } from "../../components/card/card.component";

@Component({
  selector: 'app-administrador',
  standalone: true,
  imports: [BotaoComponent, CardComponent],
  templateUrl: './administrador.component.html',
  styleUrl: './administrador.component.css'
})
export class AdministradorComponent {

}
