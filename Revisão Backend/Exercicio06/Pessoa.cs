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
                    idade = value;
                else
                    Console.WriteLine("Idade invalida.");
            }
        }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public void ExibirDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Idade: " + Idade);
        }

      
        public void Apresentar()
        {
            Console.WriteLine("Oi, meu nome é " + Nome);
        }

      
        public void Apresentar(string sobrenome)
        {
            Console.WriteLine("Oi, meu nome é " + Nome + " " + sobrenome);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa("Milena", 17);

            p1.Apresentar();
            p1.Apresentar("Julio");
        }
    }
}
