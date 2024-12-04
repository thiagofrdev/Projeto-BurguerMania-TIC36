import { CommonModule } from '@angular/common';
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BotaoComponent } from "../../../components/botao/botao.component";

@Component({
  selector: 'app-add-edit-delete',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, BotaoComponent],
  templateUrl: './add-edit-delete.component.html',
  styleUrl: './add-edit-delete.component.css'
})
export class AddEditDeleteComponent implements OnInit {
  addProductForm!: FormGroup;
  categories: any[] = []; // Lista de categorias carregadas da API
  apiUrl = "http://localhost:5106/";

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
    this.addProductForm = this.fb.group({
      name_Product: ['', Validators.required],
      path_Image_Product: ['', Validators.required],
      price_Product: [0, [Validators.required, Validators.min(0)]],
      base_Description_Product: ['', Validators.required],
      full_Description_Product: ['', Validators.required],
      category_ID: [null, Validators.required], // Campo para a categoria
    });
  }

  ngOnInit(): void {
    this.loadCategories();
  }

  // Carregar categorias da API
  loadCategories() {
    this.http.get<any>(this.apiUrl + "Categories").subscribe(
      (data) => {
        console.log('Categorias carregadas:', data);
        this.categories = data.categories.map((category: any) => ({
          id: category.iD_Category,
          name: category.name_Category,
        }));
      },
      (error) => {
        console.error('Erro ao carregar categorias:', error);
      }
    );
  }

  saveProduct(): void {
    if (this.addProductForm.valid) {
      const formValues = this.addProductForm.value;

      // Converte category_ID para número
      const productData = {
        ...formValues,
        category_ID: Number(formValues.category_ID),
      };
  
      // Enviar o formulário
      this.http.post(this.apiUrl + "Product", productData).subscribe(
        (response) => {
          console.log('Produto salvo com sucesso!', response);
          alert('Produto salvo com sucesso!');
          this.addProductForm.reset(); // Reseta o formulário após salvar
        },
        (error) => {
          console.error('Erro ao salvar produto:', error);
          alert('Erro ao salvar o produto!');
        }
      );
    } else {
      alert('Formulário inválido. Por favor, preencha todos os campos corretamente.');
    }
  }

  // Enviar dados do formulário para o backend
  onSubmit() {
    if (this.addProductForm.valid) {
      const formData = this.addProductForm.value;

      this.http.post(this.apiUrl+'Product', formData).subscribe(
        (response) => {
          console.log('Produto adicionado com sucesso!', response);
          this.router.navigate(['/administrador']); // Redireciona para a página de administração
        },
        (error) => {
          console.error('Erro ao adicionar produto:', error);
        }
      );
    }
  }

  // Cancelar ação
  onCancel() {
    this.router.navigate(['/admin']); // Redireciona para a página de administração
  }
}
