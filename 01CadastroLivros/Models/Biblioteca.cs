using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CadastroLivros.Models
{
    public class Biblioteca
    {
        private List<Livro> livros { get; set; }
        private const string arquivoJson = "Arquivos/EstoqueBiblioteca.json";

        public Biblioteca()
        {
            livros = new List<Livro>();
            CarregarBiblioteca();
        }

        private void CarregarBiblioteca ()
        {
            if (File.Exists(arquivoJson))
            {
                if (File.Exists(arquivoJson) && new FileInfo(arquivoJson).Length > 0)
                {
                    var json = File.ReadAllText (arquivoJson);
                    livros = JsonConvert.DeserializeObject<List<Livro>>(json) ?? new List<Livro>();
                }
                else
                {
                    livros = new List<Livro>();
                }
            }              
        }

        private void SalvarLivro ()
        {
            var json = JsonConvert.SerializeObject(livros, Formatting.Indented);
            File.WriteAllText(arquivoJson, json, System.Text.Encoding.UTF8);
        }

        public void AdicionarLivro(Livro livro)
        {
            var livroExistente = livros.Find(l => l.Titulo.Equals(livro.Titulo, StringComparison.OrdinalIgnoreCase) &&
                                             l.Autor.Equals(livro.Autor, StringComparison.OrdinalIgnoreCase) &&
                                             l.Ano == livro.Ano);

            if (livroExistente == null)
            {
                livros.Add(livro);
                SalvarLivro();
            }
            else
            {
                Console.WriteLine($"Este livro já existe...");
                Console.WriteLine();
            }
        }

        public void RemoverLivro(string nome)
        {   
            var livroParaRemover = livros.Find(l => l.Titulo.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (livroParaRemover != null)
            {
                livros.Remove(livroParaRemover);
                SalvarLivro();
            }
            else
            {
                Console.WriteLine("Livro inexistente.");
                Console.WriteLine();
            }
        }

        public void ListarLivros()
        {
            if (livros.Count > 0)
            {
                Console.WriteLine("--- LIVROS CADASTRADOS ---");
                Console.WriteLine();
                
                foreach (var livro in livros)
                {
                    
                    Console.WriteLine($"Título: {livro.Titulo}");
                    Console.WriteLine($"Autor: {livro.Autor}");
                    Console.WriteLine($"Ano lançamento: {livro.Ano}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Não há livros cadastrados...");
                Console.WriteLine();
            }                    
        }
    }
}
