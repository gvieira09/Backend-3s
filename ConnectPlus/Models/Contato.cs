using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

public partial class Contato
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string FormaContato { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? ImagemPath { get; set; }

    public Guid TipoContatoId { get; set; }

    [ForeignKey("TipoContatoId")]
    [InverseProperty("Contatos")]
 
    public virtual TiposContato TipoContato { get; set; } = null!;
}
