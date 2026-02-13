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
    }

    // Classe que herda de Pessoa
    public class Funcionario : Pessoa
    {
        public double Salario { get; set; }

        public Funcionario(string nome, int idade, double salario)
            : base(nome, idade)
        {
            Salario = salario;
        }

        public void ExibirFuncionario()
        {
            ExibirDados(); 
            Console.WriteLine("Salário: " + Salario);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Funcionario f1 = new Funcionario("Milena", 20, 4500.00);

            f1.ExibirFuncionario();
        }
    }
}
