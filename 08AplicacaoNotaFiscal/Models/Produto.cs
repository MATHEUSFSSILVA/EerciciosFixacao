using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08AplicacaoNotaFiscal.Models
{
    public class Produto
    {
        public Produto (string nomeProduto, int codigoProduto, decimal valorUnitario, int quantidade)
        {
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        public string NomeProduto { get; set; }
        public int CodigoProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}