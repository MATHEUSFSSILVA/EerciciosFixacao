using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _08AplicacaoNotaFiscal.Models
{
    public class GerenciadorNotas
    {
        private List<NotaFiscal> ListaNotasFiscais { get; set; } = new List<NotaFiscal>();
        private readonly string caminhoJson;

        public GerenciadorNotas ()
        {
            caminhoJson = "ArquivoJson.json";
            CarregarDados();
        }
        
        private void CarregarDados()
        {
            if (File.Exists (caminhoJson))
            {
                var json = File.ReadAllText(caminhoJson);
                ListaNotasFiscais = JsonConvert.DeserializeObject<List<NotaFiscal>>(json) ?? new List<NotaFiscal>();
            }
            else
            {
                ListaNotasFiscais = new List<NotaFiscal> ();
                SalvarDados();
                Console.WriteLine ("Arquivo Json vazio ou inexistente, criado um novo arquivo.");
            }
        }

        private void SalvarDados()
        {
            var json = JsonConvert.SerializeObject(ListaNotasFiscais, Formatting.Indented);
            File.WriteAllText(caminhoJson, json);
        }

        public void CadastrarNotaFiscal (NotaFiscal notaFiscal)
        {
            var validaNotaExistente = ListaNotasFiscais.Find (x => x.NumeroNota == notaFiscal.NumeroNota);

            if (validaNotaExistente == null)
            {
                ListaNotasFiscais.Add (notaFiscal);
                SalvarDados();
            }
            else
            {
                Console.WriteLine ("Nota fiscal já cadastrada, favor cadastrar nova nota.");
            }
        }

        public void CadastrarProdutoNotaFiscal (int numeroNotaFiscal, Produto produto)
        {
            NotaFiscal validaNumeroNota = ListaNotasFiscais.Find (x => x.NumeroNota == numeroNotaFiscal);

            if (validaNumeroNota != null)
            {
                var validaProduto = validaNumeroNota.Produtos.Find (
                    x => x.NomeProduto == produto.NomeProduto &&
                    x.CodigoProduto == produto.CodigoProduto &&
                    x.ValorUnitario == produto.ValorUnitario);

                if (validaProduto == null)
                {
                    validaNumeroNota.Produtos.Add (produto);
                    CalcularTotalNota(numeroNotaFiscal);
                    SalvarDados();
                    Console.WriteLine ($"Produto: {produto.NomeProduto} cadastrado.");
                }
                else
                {
                    Console.WriteLine("Produto já cadastrado, cadastre um novo produto.");
                }
            }
            else
            {
                Console.WriteLine("Nota fiscal inexistente, favor validar o número da nota, caso correto, cadastre a nota.");
            }
        }

        private void CalcularTotalNota (int numeroNotaFiscal)
        {
            NotaFiscal notaFiscalParaCalcularValor = ListaNotasFiscais.Find (x => x.NumeroNota == numeroNotaFiscal);

            if (notaFiscalParaCalcularValor != null)
            {
                foreach (var produto in notaFiscalParaCalcularValor.Produtos)
                {
                    notaFiscalParaCalcularValor.ValorTotalNota += produto.ValorUnitario * produto.Quantidade;
                }
            }
            else
            {
                Console.WriteLine("Nota fiscal não encontrada.");
            }
        }
    }   
}