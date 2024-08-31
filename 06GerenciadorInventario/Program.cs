using _06GerenciadorInventario.Models;

Inventario estoque = new Inventario();
Produto produto1 = new Produto(nome: "Iphone", preco:34.90M, quantidade:15);
Produto produto2 = new Produto(nome: "Nokia", preco:49.90M, quantidade:10);
Produto produto3 = new Produto(nome: "Iphone", preco:49.90M, quantidade:10);

estoque.AdicionarProdutos(produto1);
estoque.AdicionarProdutos(produto2);
estoque.ListarProdutos();

estoque.AdicionarProdutos(produto3);
// estoque.RemoverProduto("Iphone");
estoque.ListarProdutos();
estoque.AtualizarPreco(nome: "Nokia", novoPreco: 29.90M);
estoque.ListarProdutos();
estoque.VenderProduto(nome: "Iphone", quantidadeVenda: 13);
estoque.ListarProdutos();