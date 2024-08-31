using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraApp.Models
{
    public class Calculadora
    {
        public Calculadora (int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
        }

        public int Num1 { get; set; }
        public int Num2 { get; set;}

        private void MostrarResultadoCompleto (double resultadoOperacao)
        {
            var resultadoCompleto = $"O resultado para a operação entre os numeros {Num1} e {Num2} é: {resultadoOperacao}";
            Console.WriteLine(resultadoCompleto);
        }

        public void Somar ()
        {
            var resultado = Num1 + Num2;
            MostrarResultadoCompleto(resultado);
        }

        public void Multiplicar ()
        {
            var resultado = Num1 * Num2;
            MostrarResultadoCompleto(resultado);
        }

        public void Dividir ()
        {
            var resultado = Num1 / Num2;
            MostrarResultadoCompleto(resultado);
        }

        public void Subtrair ()
        {
            var resultado = Num1 - Num2;
            MostrarResultadoCompleto(resultado);
        }
    }
}