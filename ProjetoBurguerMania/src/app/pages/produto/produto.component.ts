import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-produto',
  standalone: true,
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  hamburguer: string = '';
  categoria: string = '';
  descricao: string = '';

  // Dados simulados
  detalhesHamburguer: { [key: string]: string } = {
    'X-Alface': 'Hambúrguer vegano com alface fresca e molho especial.',
    'X-Tomate': 'Hambúrguer com tomate, queijo vegano e molho especial.',
    'X-Bacon': 'Hambúrguer tradicional com bacon crocante e cheddar.',
    // Adicione mais aqui...
  };

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.categoria = params['categoria'];
      this.hamburguer = params['hamburguer'];
      this.descricao = this.detalhesHamburguer[this.hamburguer] || 'Descrição não disponível.';
    });
  }
}