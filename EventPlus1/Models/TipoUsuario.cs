using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus1.Models;

[Table("TipoUsuario")]
public partial class TipoUsuario
{
    [Key]
    public Guid IdTipoUsuario { get; set; }

    [StringLength(20)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdTipoUsuarioNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
