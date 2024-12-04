import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { BotaoComponent } from "../../components/botao/botao.component";
import { ProdutoService } from '../../services/produto/produto.service';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatOptionModule } from '@angular/material/core';


@Component({
  selector: 'app-pedido',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule, 
    CommonModule, 
    BotaoComponent, 
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    MatOptionModule],
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {
  pedidoForm: FormGroup;
  totalPrice: number = 0;
  productsList: any[] = [];
  filteredProducts: any[] = [];

  constructor(private fb: FormBuilder, private http: HttpClient, private produtoService: ProdutoService) {
    this.pedidoForm = this.fb.group({
      userName: ['', Validators.required],
      userEmail: ['', [Validators.required, Validators.email]],
      products: this.fb.array([]),
    });
  }

  ngOnInit() {
    this.addProduct(); // Adiciona um campo de produto inicial

    // Carrega todos os produtos para o autocomplete
    this.produtoService.getAllProducts().subscribe(
      (response) => {
        this.productsList = response?.products || [];
      },
      (error) => {
        console.error('Erro ao carregar a lista de produtos:', error);
      }
    );
  }

  // Método para filtrar os produtos
  filterProducts(event: Event) {
    const input = event.target as HTMLInputElement; // Fazendo o cast para HTMLInputElement
    const value = input.value;

    if (value) {
      this.produtoService.getProductByName(value).subscribe(response => {
        const filterValue = value.toLowerCase();
        this.filteredProducts = response.products.filter((product) =>
          product.name_Product.toLowerCase().includes(filterValue)
        );
      });
    } else {
      this.filteredProducts = [];
    }
  }

  // Método para selecionar um produto no autocomplete
  onProductSelected(productName: string) {
    const product = this.productsList.find((p) => p.name_Product === productName);
    if (product) {
      const productGroup = this.fb.group({
        productName: [product.name_Product, Validators.required], // Aqui você ainda precisa do nome
        quantity: [1, [Validators.required, Validators.min(1)]],
        unitPrice: [product.price_Product, Validators.required],
        totalPrice: [product.price_Product, Validators.required],
        productID: [product.product_ID, Validators.required], // Supondo que o produto tenha um ID
      });

      // Atualiza a lista de produtos no pedido
      this.products.push(productGroup);
      this.calculateTotalPrice();
    }
  }

  get products() {
    return this.pedidoForm.get('products') as FormArray;
  }

  addProduct() {
    const productGroup = this.fb.group({
      productName: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      unitPrice: [0, Validators.required],
      totalPrice: [0, Validators.required],
    });

    // Busca o produto ao mudar o nome
    productGroup.get('productName')?.valueChanges.subscribe((name) => {
      if (name && name.trim() !== '') { // Evita chamadas para strings vazias
        this.produtoService.getProductByName(name).subscribe(
          (response) => {
            const product = response?.products?.find((p: any) => p.name_Product === name);
            if (product) {
              productGroup.patchValue({
                unitPrice: product.price_Product,
                totalPrice: product.price_Product * (productGroup.get('quantity')?.value || 1),
              });
            }
          },
          (error) => {
            console.error('Erro ao buscar produto:', error);
          }
        );
      }
    });

    // Observa mudanças nos campos "quantity" e "unitPrice"
    productGroup.get('quantity')?.valueChanges.subscribe(() => this.updateProdutoPreco(productGroup));
    productGroup.get('unitPrice')?.valueChanges.subscribe(() => this.updateProdutoPreco(productGroup));

    this.products.push(productGroup);
  }

  updateProdutoPreco(productGroup: FormGroup) {
    const quantity = productGroup.get('quantity')?.value || 0;
    const unitPrice = productGroup.get('unitPrice')?.value || 0;
    const totalPrice = quantity * unitPrice;

    // Atualiza o preço total do produto
    productGroup.get('totalPrice')?.setValue(totalPrice, { emitEvent: false });

    // Recalcula o preço total da compra
    this.calculateTotalPrice();
  }

  calculateTotalPrice() {
    this.totalPrice = this.products.controls.reduce((sum, product) => {
      return sum + (product.get('totalPrice')?.value || 0);
    }, 0);
  }

  updateTotalPrice(index: number) {
    const product = this.products.at(index);
    const quantity = product.get('quantity')?.value || 0;
    const unitPrice = product.get('unitPrice')?.value || 0;

    product.patchValue({
      totalPrice: quantity * unitPrice,
    });

    this.calculateTotalPrice();
  }

  submitOrder() {
    if (this.pedidoForm.valid) {
      const formData = {
        value_Order: this.totalPrice, // Usando o valor total calculado
        status_ID: 0,   // Se você precisar de um status, defina o valor adequado
        user_ID: 0,     // Substitua pelo ID correto do usuário, se necessário
        products: this.products.value.map((product: any) => ({
          product_ID: product.productID, // Usando o ID real do produto
          quantity: product.quantity
        }))
      };

      this.http.post('http://localhost:5106/Order', formData).subscribe(
        (response) => {
          alert('Pedido enviado com sucesso!');
          console.log(response);
        },
        (error) => {
          alert('Erro ao enviar o pedido. Verifique os dados e tente novamente.');
          console.error('Erro ao enviar pedido:', error);
        }
      );
    }
  }
}