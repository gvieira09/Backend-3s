using System;

namespace Exercicio01
{
    public class Pessoa
    {
        public string Nome;
        public int Idade;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa();

            p1.Nome = "Guilherme";
            p1.Idade = 16;

            Console.WriteLine("Nome: " + p1.Nome);
            Console.WriteLine("Idade: " + p1.Idade);
        }
    }
}
