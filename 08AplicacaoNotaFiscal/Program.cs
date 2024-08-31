using _08AplicacaoNotaFiscal.Models;

Produto produto1 = new Produto(nomeProduto: "Garrafa térmica", codigoProduto: 3512673, valorUnitario: 0.12M, quantidade: 32);
Produto produto2 = new Produto(nomeProduto: "Celular Nokia", codigoProduto: 9234512, valorUnitario: 15.90M, quantidade: 15);
NotaFiscal notaFiscal = new NotaFiscal(razaoSocialCliente: "Drad Produtos Eletronicos", numeroNota: 123456, dataNota: new DateTime(2024, 08, 30));

GerenciadorNotas gerenciadorNotas = new GerenciadorNotas();

gerenciadorNotas.CadastrarNotaFiscal(notaFiscal);
gerenciadorNotas.CadastrarProdutoNotaFiscal(numeroNotaFiscal: 123456, produto1);
gerenciadorNotas.CadastrarProdutoNotaFiscal(numeroNotaFiscal: 123456, produto2);