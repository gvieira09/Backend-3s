using System;

namespace Exercicio01
{
    public class Veiculo
    {
        public virtual void Mover()
        {
            Console.WriteLine("O veículo está se movendo.");
        }
    }

    public class Carro : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("O carro está andando com motor.");
        }
    }

    public class Bicicleta : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("A bicicleta se move com o pedal.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Veiculo v1 = new Carro();
            Veiculo v2 = new Bicicleta();

            v1.Mover();
            v2.Mover();
        }
    }
}
