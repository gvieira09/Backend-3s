using System.ComponentModel.DataAnnotations;

namespace EventPlus1.DTO;

public class TipoUsuarioDTO
{
    [Required(ErrorMessage = "O título do tipo usuário é obrigatório.")]
    public string? Titulo { get; set; }
}
