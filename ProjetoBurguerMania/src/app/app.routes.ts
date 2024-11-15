import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidoComponent } from './pages/pedido/pedido.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';

const routes: Routes = [
    { path: '', redirectTo: '/pedido', pathMatch: 'full' },
    { path: 'pedido', component: PedidoComponent },
    { path: 'cardapio', component: CardapioComponent },
    { path: 'cardapio/:categoria', component: CardapioComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }