using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Utils;
using EventPlus1.BdContextEvento;
using EventPlus1.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly EventosContext _context;

    public UsuarioRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuário pelo e-mail e valida o hash da senha
    /// </summary>
    /// <param name="Email">email do usuárop</param>
    /// <param name="Senha">senha do usuário</param>
    /// <returns>Usuario buscado e validado</returns>
    public Usuario BuscarEmailESenha(string Email, string Senha)
    {
        var usuarioBuscado = _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.Email == Email);

        if (usuarioBuscado != null)
        {
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);
            if(confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }

    /// <summary>
    /// Busca um usuário pelo Id, incluindo os dados do seu tipo usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário a ser buscado</param>
    /// <returns>Usuário buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
                    .Include(usuario => usuario.IdTipoUsuarioNavigation)
                    .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuário, com a senha criptografada
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
