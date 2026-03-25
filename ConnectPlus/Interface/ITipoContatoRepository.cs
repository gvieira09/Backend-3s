using System.Collections.Generic;
using ConnectPlus.Models;

namespace ConnectPlus.WebAPI.Interface
{
    public interface ITipoContatoRepository
    {
        void Cadastrar(TiposContato tipo);
        List<TiposContato> Listar();
        TiposContato BuscarPorId(Guid id);
        void Atualizar(TiposContato tipo);
        void Deletar(Guid id);
    }
}