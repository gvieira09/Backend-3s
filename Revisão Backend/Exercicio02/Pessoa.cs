using System;

namespace Exercicio01
{
    public class Pessoa
    {
        public string Nome;
        public int Idade;

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
            p1.Idade = 16;

            p1.ExibirDados();
        }
    }
}
