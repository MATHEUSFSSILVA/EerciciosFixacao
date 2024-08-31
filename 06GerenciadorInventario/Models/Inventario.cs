using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _06GerenciadorInventario.Models
{
    public class Inventario
    {
        private List<Produto> Produtos;
        private readonly string caminhoJson = "EstoqueProdutos.json"; 

        public Inventario()
        {
            Produtos = new List<Produto>();
            CarregarDados();
        }

        private void CarregarDados()
        {
            var json = File.ReadAllText(caminhoJson);
            Produtos = JsonConvert.DeserializeObject<List<Produto>>(json) ?? new List<Produto>();
        }

        private void SalvarDados()
        {
            var json = JsonConvert.SerializeObject(Produtos, Formatting.Indented);
            File.WriteAllText(caminhoJson, json);            
        }

        public void AdicionarProdutos(Produto produto)
        {
            var validarProduto = Produtos.Find(x => x.Nome == produto.Nome);

            if (validarProduto == null)
            {
                Produtos.Add(produto);
                SalvarDados();
            }
            else
            {
                Console.WriteLine($"Produto já costa no sistema.");
            }
        }

        public void RemoverProduto(string produto)
        {
            var validarProduto = Produtos.Find(x => x.Nome == produto);

            if (validarProduto != null)
            {
                Produtos.Remove(validarProduto);
                SalvarDados();
            }
        }

        public void AtualizarPreco(string nome, decimal novoPreco)
        {
            var produtoExistente = Produtos.Find(x => x.Nome == nome);

            if (produtoExistente != null)
            {
                produtoExistente.Preco = novoPreco;
                Console.WriteLine($"Valor de {produtoExistente.Nome} atualizado para {produtoExistente.Preco:C}.");
                SalvarDados();
            }
            else
            {
                Console.WriteLine($"Produto '{nome}' não encontrado.");
            }
        }
        
        public void VenderProduto(string nome, int quantidadeVenda)
        {
            if (quantidadeVenda <= 0)
            {
                Console.WriteLine($"A quantidade a ser vendida deve ser maior que zero.");
            }

            var produtoVenda = Produtos.Find(x => x.Nome == nome);

            if (produtoVenda != null)
            {
                if (produtoVenda.Quantidade >= quantidadeVenda)
                {
                    produtoVenda.Quantidade -= quantidadeVenda;               
                    SalvarDados();
                }
                else
                {
                    Console.WriteLine($"Não é possível realizar a venda, quantidade em estoque: {produtoVenda.Quantidade}.");
                }
            }
            else
            {
                Console.WriteLine($"Produto não encontrado.");
            }

        }

        public void ListarProdutos()
        {
            if (Produtos.Count > 0)
            {
                foreach (Produto produto in Produtos.Where(x => x.Quantidade > 0))
                {
                    Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco:C}, Quantidade: {produto.Quantidade}");
                }
            }
            else
            {
                Console.WriteLine("Não há produtos para listar.");
            }
        }
    }
}