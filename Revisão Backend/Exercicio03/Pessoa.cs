using System;

namespace Exercicio01
{
    public class Pessoa
    {
        public string Nome { get; set; }

        private int idade;

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value > 0)
                {
                    idade = value;
                }
                else
                {
                    Console.WriteLine("Idade invalida. Deve ser maior que zero.");
                }
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Idade: " + Idade);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa();

            p1.Nome = "Guilherme";
            p1.Idade = -5;   
            p1.Idade = 2;   

            p1.ExibirDados();
        }
    }
}
