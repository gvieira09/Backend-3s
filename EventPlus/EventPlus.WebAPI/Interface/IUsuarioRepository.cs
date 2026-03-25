using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IUsuarioRepository
{
     void Cadastrar(Usuario usuario);

    Usuario BuscarPorId(Guid IdUsuario);

    Usuario BuscarEmailESenha(string Email, string Senha);
    
}
