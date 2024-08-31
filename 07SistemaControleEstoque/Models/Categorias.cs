using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace _07SistemaControleEstoque.Models
{
    public class Categorias
    {
        public List<Produto> Produtos;
        
        public Categorias (string nome)
        {
            NomeCategoria = nome;
            Produtos = new List<Produto>();
        }

        public string NomeCategoria { get; set; } 
    }
}