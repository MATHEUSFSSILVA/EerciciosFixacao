using System.IO.Pipes;
using CadastroLivros.Models;

Biblioteca biblioteca = new Biblioteca();
Livro novoLivro1 = new Livro(titulo: "O Senhor dos Anéis", autor: "J.R.R. Tolkien", ano: 1954);
Livro novoLivro2 = new Livro(titulo: "O Hobbit", autor: "J.R.R. Tolkien", ano: 1937);
Livro novoLivro3 = new Livro(titulo: "As Crônicas de Nárnia", autor: "C.S. Lewis", ano: 1950);
Livro novoLivro4 = new Livro(titulo: "Harry Potter e a Pedra Filosofal", autor: "J.K. Rowling", ano: 1997);
biblioteca.AdicionarLivro(novoLivro1);
biblioteca.AdicionarLivro(novoLivro2);
biblioteca.AdicionarLivro(novoLivro3);
biblioteca.AdicionarLivro(novoLivro4);
// biblioteca.RemoverLivro("O Senhor dos Anéis");
biblioteca.ListarLivros();