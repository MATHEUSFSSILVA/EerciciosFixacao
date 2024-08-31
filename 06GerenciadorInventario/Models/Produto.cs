using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06GerenciadorInventario.Models
{
    public class Produto
    {
        public Produto(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}