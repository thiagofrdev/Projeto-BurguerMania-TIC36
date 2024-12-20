import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PedidoComponent } from './pages/pedido/pedido.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { CategoriaComponent } from './pages/categoria/categoria.component';
import { LocalizacaoComponent } from './pages/localizacao/localizacao.component';
import { ContatoComponent } from './pages/contato/contato.component';
import { ProdutoComponent } from './pages/produto/produto.component';
import { AdministradorComponent } from './pages/administrador/administrador.component';
import { AddEditDeleteComponent } from './pages/administrador/add-edit-delete/add-edit-delete.component';

// Definição das rotas da URL para cada página
export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'pedido', component: PedidoComponent },
    { path: 'cardapio', component: CardapioComponent },
    { path: 'categoria/:categoria', component: CategoriaComponent },
    { path: 'categoria/:id', component: CategoriaComponent },
    { path: 'categoria/:categoria/:produto', component: ProdutoComponent },
    { path: 'localizacao', component: LocalizacaoComponent },
    { path: 'contato', component: ContatoComponent },

    { path: 'administrador', component: AdministradorComponent},
    { path: 'admin/add', component: AddEditDeleteComponent },
    { path: 'admin/edit', component: AddEditDeleteComponent },
    { path: 'admin/delete', component: AddEditDeleteComponent }
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }