using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace JogoAdivinhacao.Models
{
    public class Jogo
    {
        public Jogo ()
        {
            NumeroSorteado = Sortear();
        }

        private int NumeroSorteado { get; set; }

        private int Sortear()
        {
            Random random = new Random();
            return random.Next(1, 11);
        }

        public void Jogar()
        {
            bool validarResultado = false;
            int numeroJogador = 0;
            
            while (!validarResultado)
            {   
                bool validadorEntrada = false;

                while (!validadorEntrada)
                {
                    Console.WriteLine("Digite um número inteiro: ");
                    string entrada = Console.ReadLine();
                    validadorEntrada = int.TryParse(entrada, out numeroJogador);                
                }

                if (numeroJogador <= 0)
                {
                    Console.WriteLine("O número digitado deve ser maior que 0.");
                }
                else if (numeroJogador > 10)
                {
                    Console.WriteLine("O número digitado deve ser de 1 à 10.");
                }
                else
                {
                    validarResultado = ValidarPalpite(numeroJogador);
                }
            }
        }
        
        private bool ValidarPalpite(int numeroJogador)
        {
            if (numeroJogador == NumeroSorteado)
                {
                    Console.WriteLine($"PARABÉNS, VOCÊ ACERTOU! O número sorteado é {NumeroSorteado}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Você errou, continue tentando.");
                    return false;
                }
        }
    }
}