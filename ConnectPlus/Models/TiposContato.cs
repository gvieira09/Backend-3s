using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConnectPlus.Models;

[Table("TiposContato")]
public partial class TiposContato
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("TipoContato")]
    [JsonIgnore]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
