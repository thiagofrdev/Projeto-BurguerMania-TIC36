import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PedidoComponent } from './pages/pedido/pedido.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { ProdutoComponent } from './pages/produto/produto.component';
import { LocalizacaoComponent } from './pages/localizacao/localizacao.component';
import { ContatoComponent } from './pages/contato/contato.component';


//Definição das rotas da URL para cada página
export const routes: Routes = [
    { path: '', component: HomeComponent }, // Rota Home
    { path: 'categoria', component: CardapioComponent }, // Rota Pedido
    { 
        path: 'cardapio', 
        component: CardapioComponent, // Página do cardápio
        children: [
            { path: ':categoria', component: CardapioComponent }, // Página de categoria
            { path: ':categoria/:produto', component: ProdutoComponent } // Página do produto específico
        ]
    },
    { path: 'localizacao', component: LocalizacaoComponent }, // Rota de Localização
    { path: 'contato', component: ContatoComponent }, // Rota de Contato
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }