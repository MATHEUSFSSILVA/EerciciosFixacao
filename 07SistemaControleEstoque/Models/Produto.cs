using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07SistemaControleEstoque.Models
{
    public class Produto
    {
        public Produto (string nome, int quantidade, decimal preco)
        {   
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}