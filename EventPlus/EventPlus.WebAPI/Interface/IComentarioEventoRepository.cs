using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);

    void Deletar(Guid idComentarioEvento);

    List<ComentarioEvento> Listar(Guid idEvento);
    ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    List<ComentarioEvento> ListarSomenteExibe(Guid idEvento);

}
