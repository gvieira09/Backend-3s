using System.ComponentModel.DataAnnotations;

namespace EventPlus1.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email do usuário é obrigatório.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha do usuário é obrigatório.")]
    public string? Senha { get; set; }
    public Guid? IdTipoUsuario { get; set; }
}
