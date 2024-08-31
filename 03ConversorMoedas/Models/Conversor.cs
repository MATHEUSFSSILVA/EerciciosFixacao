using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConversorMoedas.Models
{
    public class Conversor
    {
        public Conversor(decimal valor)
        {
            Valor = valor;
        }

        public decimal Valor { get; set; }

        public void ConverterMoedas()
        {   
            // Configure o valor das moedas em relação ao dólar;

            decimal dolar = 1M;
            decimal real = 5.51M;
            decimal euro = 0.89M;

            Console.WriteLine("A seguir digite a opção de conversão:\n" +
                                "DOL - Dólar\n" +
                                "BRL - Real\n" +
                                "EUR - Euro\n");
            
            List<string> moedas = new List<string> {"DOL", "BRL", "EUR"};
            
            bool moedaValidada = false;
            string avisoErro = "Moeda incorreta, digite conforme as opções acima";
            string moedaInicio = "";
            string moedaFinal = "";

            while (!moedaValidada)
            {
                Console.WriteLine("Digite qual a moeda inicial: ");
                moedaInicio = Console.ReadLine().ToUpper();

                if (moedas.Contains(moedaInicio))
                {
                    moedaValidada = true;
                }
                else
                {
                    Console.WriteLine(avisoErro);
                }
            }

            moedaValidada = false;
            
            while (!moedaValidada)
            {
                Console.WriteLine("Digite qual a moeda final: ");
                moedaFinal = Console.ReadLine().ToUpper();

                if (moedas.Contains(moedaFinal))
                {
                    moedaValidada = true;
                }
                else
                {
                    Console.WriteLine(avisoErro);
                }
            }

            decimal moedaConvertida = Calculo(moedaInicio, moedaFinal, Valor, real, euro, dolar);

            Console.WriteLine($"{moedaInicio}:{Valor:C} ---- {moedaFinal}:{moedaConvertida:C}");
        }

        private decimal Calculo(string moedaInicio, string moedaFinal, decimal valor, decimal real, decimal euro, decimal dolar)
        {
            // Converter para dolar.
            decimal valorEmDolar = valor;

            if (moedaInicio == "BRL")
            {
                valorEmDolar = valor / real;
            }
            else if (moedaInicio == "EUR")
            {
                valorEmDolar = valor / euro;
            }

            // Converter o valor em dolar para a moeda de cambio.
            if (moedaFinal == "BRL")
            {
                return valorEmDolar * real;
            }
            else if (moedaFinal == "EUR")
            {
                return valorEmDolar * euro;
            }
            else
            {
                return valorEmDolar;
            }
        }
    }
}