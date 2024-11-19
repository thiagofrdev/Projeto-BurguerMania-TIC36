import { Component } from '@angular/core';
import { HeaderComponent } from "../components/header/header.component";
import { BotaoComponent } from "../components/botao/botao.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, BotaoComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

}
