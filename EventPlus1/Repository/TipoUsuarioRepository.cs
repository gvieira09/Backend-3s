using EventPlus.WebAPI.Interface;
using EventPlus1.BdContextEvento;
using EventPlus1.Models;

namespace EventPlus.WebAPI.Repository;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventosContext _context;

    public TipoUsuarioRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de usuário 
    /// </summary>
    /// <param name="id">id do tipo usuário</param>
    /// <param name="tipoUsuario">Novos dados do tipo usuário</param>
    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);
            
        if(tipoUsuario != null)
        {
            tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

        }
        _context.SaveChanges();
    }

    /// <summary>
    /// Busca um tipo usuario por id
    /// </summary>
    /// <param name="id">id do tipo usuario a ser buscado</param>
    /// <returns>objeto do tipousuario com as informacoes do tipo de usuario buscado</returns>
    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo tipo de usuário
    /// </summary>
    /// <param name="tipoUsuario">Tipo de usuario a ser cadastrado</param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de usuário
    /// </summary>
    /// <param name="id">id do tipo usuario a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if(tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipos de usuários cadastrados
    /// </summary>
    /// <returns>Uma lista de tipo usuarios</returns>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.ToList();
    }
}
