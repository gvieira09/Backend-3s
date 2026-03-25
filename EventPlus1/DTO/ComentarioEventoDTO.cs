using System.ComponentModel.DataAnnotations;

namespace EventPlus1.DTO
{
    public class ComentarioEventoDTO
    {
     
        public string? Descricao { get; set; }

      
        public Guid? IdEvento { get; set; }

       
        public Guid? IdUsuario { get; set; }
    }
}
