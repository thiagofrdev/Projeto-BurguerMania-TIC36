import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PedidoComponent } from './pages/pedido/pedido.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';

//Definição das rotas da URL para cada página
export const routes: Routes = [
    { path: '', component: HomeComponent }, //Rota vazia para a home 
    { path: 'pedido', component: PedidoComponent }, //Rota "/pedido" para a pagina de pedido
    { path: 'cardapio', component: CardapioComponent }, //Rota "/cardapio" para a pagina do cardápio
    { path: 'cardapio/:categoria', component: CardapioComponent } //Rota "/cardapio/categoria" para mostrar a página da categoria do produto
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }