using System;

namespace Exercicio04
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

        // Construtor
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
    }



}
