using _07SistemaControleEstoque.Models;

Gerenciador estoque = new Gerenciador();
estoque.ListarProdutos();

Console.WriteLine("----------------- CADASTRAR CATEGORIAS -----------------");

Categorias categoria1 = new Categorias(nome: "Celulares");
Categorias categoria2 = new Categorias(nome: "Computadores");
estoque.CadastrarCategoria(categoria1);
estoque.CadastrarCategoria(categoria2);

Console.WriteLine("----------------- CADASTRAR PRODUTOS -----------------");

Produto produto1= new Produto(nome: "Iphone", quantidade: 30, preco: 150.90M);
Produto produto2= new Produto(nome: "Nokia", quantidade: 20, preco: 100M);
Produto produto3= new Produto(nome: "Motorola", quantidade: 10, preco: 200.90M);

estoque.CadastrarProduto(categoriaProdutoCadastrar: "Celulares", produto: produto1);
estoque.CadastrarProduto(categoriaProdutoCadastrar: "Celulares", produto: produto2);
estoque.CadastrarProduto(categoriaProdutoCadastrar: "Celulares", produto: produto3);

Produto produto4= new Produto(nome: "NotBook Samsumg", quantidade: 5, preco: 200M);
Produto produto5= new Produto(nome: "Acer", quantidade: 3, preco: 100M);
Produto produto6= new Produto(nome: "Lenovo desktop", quantidade: 10, preco: 999.99M);

estoque.CadastrarProduto(categoriaProdutoCadastrar: "Computadores", produto: produto4);
estoque.CadastrarProduto(categoriaProdutoCadastrar: "Computadores", produto: produto5);
estoque.CadastrarProduto(categoriaProdutoCadastrar: "Computadores", produto: produto6);

Console.WriteLine("----------------- REMOVER PRODUTOS -----------------");

estoque.RemoverProduto(categoriaProduto: "Computadores", nomeProdutoRemover: "Acer");