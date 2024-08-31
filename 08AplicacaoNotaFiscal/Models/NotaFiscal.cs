using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _08AplicacaoNotaFiscal.Models
{
    public class NotaFiscal
    {
        public NotaFiscal (string razaoSocialCliente, int numeroNota, DateTime dataNota)
        {   
            RazaoSocialCliente = razaoSocialCliente;
            Produtos = new List<Produto>();
            NumeroNota = numeroNota;
            DataNota = dataNota;
        }
        public string RazaoSocialCliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public int NumeroNota { get; set; }
        public DateTime DataNota { get; set; }
        public decimal ValorTotalNota { get; set; } = 0;
    }   
}