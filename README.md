# Projeto Burguer Mania 🍔
Este é um projeto de um **site responsivo para uma hamburgueria**, desenvolvido como parte da Unidade 9 da **Residência em Software TIC 36**. O objetivo do projeto é oferecer uma experiência intuitiva e agradável para os clientes, com informações sobre o cardápio, localização e formas de contato.

## 🚀 Tecnologias Utilizadas
- **Frontend**: HTML, CSS, TypeScript, Angular
- **Backend**: .NET, Entity Framework
- **Banco de Dados**: PostgreSQL

## 📥 Como Rodar o Projeto na Sua Máquina

Siga os passos abaixo para baixar e executar o projeto localmente:

### 1. Clonar o Repositório
**Clone o repositório no seu computador**:
  ```
  git clone https://github.com/seu-usuario/nome-do-repositorio.git
  ```

### 2. Configurar o Backend (.NET):
1. Certifique-se de ter o .NET SDK instalado na sua máquina.
2. No diretório do backend:
- Configure a string de conexão no arquivo appsettings.json para o PostgreSQL:
  ```
  {
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=BurguerManiaDB;Username=seu_usuario;Password=sua_senha"
    }
  }
  ```
- Rode os comandos para aplicar as migrações:
  ```
  dotnet ef database update
  ```
- Inicie o servidor:
  ```
  dotnet run
  ```

### 3. Configurar o Frontend (Angular):

1. Certifique-se de ter o Node.js e o Angular CLI instalados.
2. No diretório do frontend, instale as dependências:
  ```
  npm install
  ```
3. Inicie o servidor Angular:
  ```
  ng serve
  ```
4. Acesse a aplicação no navegador em: http://localhost:4200.

# 🌟 Funcionalidades
**Para os Clientes:**
- Fazer Pedido: Adicione itens ao carrinho e finalize a compra.
- Ver Produtos: Navegue pela lista de produtos disponíveis com detalhes.
**Para o Administrador:**
- Adicionar Produtos: Insira novos itens no catálogo de produtos.
- Atualizar Produtos: Edite informações como nome, preço e descrição.
- Excluir Produtos: Remova itens do catálogo.
- Gerenciar Pedidos: Visualize e altere o status de pedidos realizados.

# 🔮 Futuras Melhorias
- Correção de Bugs: Ajustar possíveis problemas de responsividade ou integrações.
- Implementação de Login: Adicionar autenticação para clientes e administradores.
- Aprimoramento do Design: Melhorar a interface para oferecer uma experiência mais amigável.

#
Sinta-se à vontade para contribuir com melhorias ou reportar problemas através da aba Issues do repositório! 🚀😊