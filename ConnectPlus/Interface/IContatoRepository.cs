using ConnectPlus.Models;

namespace ConnectPlus.WebAPI.Interfaces
{
    public interface IContatoRepository
    {

        Contato BuscarPorId(Guid id);

        void Atualizar(Contato contato);

        void Deletar(Guid id);

        List<Contato>listar();
        void Cadastrar(Contato contato);
    }
}
