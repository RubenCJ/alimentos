using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datos.Context;

[Table("Alimento")]
public partial class Alimento
{
    [Key]
    [Column("idAlimento")]
    public int IdAlimento { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("costo", TypeName = "numeric(10, 2)")]
    public decimal Costo { get; set; }

    [Column("fechaRegistro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [Column("fechaActualizacion", TypeName = "datetime")]
    public DateTime? FechaActualizacion { get; set; }

    [Column("activo")]
    public bool Activo { get; set; }

    [ForeignKey("IdAlimento")]
    [InverseProperty("IdAlimentos")]
    public virtual ICollection<Ingrediente> IdIngredientes { get; set; } = new List<Ingrediente>();
}
