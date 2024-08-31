using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _07SistemaControleEstoque.Models
{
    public class Gerenciador
    {
        private List<Categorias> Categoria;
        private readonly string caminhoJson;

        public Gerenciador()
        {
            caminhoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EstoqueProdutos.json");
            Categoria = new List<Categorias>();
            CarregarDados();
        }

        private void CarregarDados()
        {   
            if (File.Exists(caminhoJson))
            {
                var json = File.ReadAllText(caminhoJson);
                Categoria = JsonConvert.DeserializeObject<List<Categorias>>(json) ?? new List<Categorias>();
            }
            else
            {
                Categoria = new List<Categorias>();
                SalvarDados();
                Console.WriteLine($"Arquivo estoque não encontrado, iniciando um novo arquivo.");
            }
        }

        private void SalvarDados()
        {
            var json = JsonConvert.SerializeObject(Categoria, Formatting.Indented);
            File.WriteAllText(caminhoJson, json);
        }

        public void CadastrarCategoria(Categorias categoriaCriar)
        {
            var validarCategoria = Categoria.Find(x => x.NomeCategoria == categoriaCriar.NomeCategoria);

            if (validarCategoria == null)
            {
                Categoria.Add(categoriaCriar);
                SalvarDados();
                Console.WriteLine($"Categoria {categoriaCriar.NomeCategoria} cadastrada.");
            }
            else
            {
                Console.WriteLine("Categoria já existente.");
            }
        }

        public void CadastrarProduto(string categoriaProdutoCadastrar, Produto produto)
        {   
            Categorias verificaCategoriaExiste = Categoria.Find(x => x.NomeCategoria == categoriaProdutoCadastrar);

            if (verificaCategoriaExiste != null)
            {
                var verificaProdutoExiste = verificaCategoriaExiste.Produtos.Find(x => x.Nome == produto.Nome);

                if (verificaProdutoExiste == null)
                {
                    verificaCategoriaExiste.Produtos.Add(produto);
                    SalvarDados();
                    Console.WriteLine($"Produto Cadastrado: {produto.Nome}.");
                }
                else
                {
                    Console.WriteLine("Produto já existente.");
                }
            }
            else
            {
                Console.WriteLine("Categoria inexistente, certifique-se que a categoria existe.");
            }
        }

        public void RemoverProduto(string categoriaProduto, string nomeProdutoRemover)
        {
            var verificaCategoria = Categoria.Find(x => x.NomeCategoria == categoriaProduto);

            if (verificaCategoria != null)
            {
                var verificaProduto = verificaCategoria.Produtos.Find(x => x.Nome == nomeProdutoRemover);

                if (verificaProduto != null)
                {
                    verificaCategoria.Produtos.Remove(verificaProduto);
                    SalvarDados();
                    Console.WriteLine($"Produto removido: {verificaProduto.Nome}.");
                }
                else
                {
                    Console.WriteLine("Produto inexistente nessa categoria.");
                }
            }
            else
            {
                Console.WriteLine("Categoria inexistente.");
            }
        }

        public void ListarProdutos()
        {
            if (Categoria.Count > 0)
            {
                foreach (var categoria in Categoria)
                {
                    Console.WriteLine($"Categoria: {categoria.NomeCategoria} ");
                    if (categoria.Produtos != null && categoria.Produtos.Count > 0)
                    {
                        foreach (var produto in categoria.Produtos)
                        {
                            Console.WriteLine($"Produto: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhum produto cadastrado.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Cadastre ao menos uma categoria.");
            }           
        }
    }
}