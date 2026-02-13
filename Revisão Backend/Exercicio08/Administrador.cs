public class Administrador : IAutenticavel
{
    public string Nome { get; set; }
    private string Senha { get; set; }

    public Administrador(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public bool Autenticar(string senha)
    {
        return Senha == senha;
    }
}
