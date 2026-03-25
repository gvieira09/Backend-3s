using System.ComponentModel.DataAnnotations;

namespace EventPlus1.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O Nome Fantasia da instituição é obrigatório.")]
    public string? NomeFantasia { get; set; }

    [Required(ErrorMessage = "O CNPJ da instituição é obrigatório.")]
    public string? CNPJ { get; set; }

    [Required(ErrorMessage = "O Endereço da instituição é obrigatório.")]
    public string? Endereco { get; set; }

}
