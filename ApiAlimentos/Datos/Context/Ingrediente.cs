using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datos.Context;

[Table("Ingrediente")]
public partial class Ingrediente
{
    [Key]
    [Column("idIngrediente")]
    public int IdIngrediente { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("IdIngrediente")]
    [InverseProperty("IdIngredientes")]
    public virtual ICollection<Alimento> IdAlimentos { get; } = new List<Alimento>();
}
