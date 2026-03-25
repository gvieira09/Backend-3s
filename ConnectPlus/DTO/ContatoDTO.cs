namespace ConnectPlus.WebAPI.DTOs
{
    public class ContatoResponseDTO
    {
        public string? Nome { get; set; }
        public string? FormaContato { get; set; }
        public Guid TipoContatoId { get; set; }
        public IFormFile? ImagemPath { get; set; }
    }
}