import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BotaoComponent } from "../../components/botao/botao.component";
import { CardComponent } from "../../components/card/card.component";
import { AddEditDeleteComponent } from './add-edit-delete/add-edit-delete.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-administrador',
  standalone: true,
  imports: [CommonModule, RouterModule, BotaoComponent, CardComponent, AddEditDeleteComponent],
  templateUrl: './administrador.component.html',
  styleUrl: './administrador.component.css'
})
export class AdministradorComponent {
  currentAction: {
    type: "adicionar" | "editar" | "excluir";
    target: "produto" | "categoria";
  } | null = null;

  setAction(type: "adicionar" | "editar" | "excluir", target: "produto" | "categoria") {
    this.currentAction = { type, target };
  }

  clearAction() {
    this.currentAction = null; //Reseta para fechar o componente dinâmico
  }
}
