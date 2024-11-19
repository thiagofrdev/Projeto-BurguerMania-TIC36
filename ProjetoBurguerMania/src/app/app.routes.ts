import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PedidoComponent } from './pages/pedido/pedido.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { CategoriaComponent } from './pages/categoria/categoria.component';
import { LocalizacaoComponent } from './pages/localizacao/localizacao.component';
import { ContatoComponent } from './pages/contato/contato.component';

// Definição das rotas da URL para cada página
export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'pedido', component: PedidoComponent },
    { path: 'cardapio', component: CardapioComponent },
    { path: 'categoria/:categoria', component: CategoriaComponent },
    { path: 'localizacao', component: LocalizacaoComponent },
    { path: 'contato', component: ContatoComponent },
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }