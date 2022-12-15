using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.Context;

public partial class AlimentosContext : DbContext
{
    public AlimentosContext()
    {
    }

    public AlimentosContext(DbContextOptions<AlimentosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alimento> Alimentos { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alimento>(entity =>
        {
            entity.HasKey(e => e.IdAlimento).HasName("PK_alimento");

            entity.HasMany(d => d.IdIngredientes).WithMany(p => p.IdAlimentos)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredienteAlimento",
                    r => r.HasOne<Ingrediente>().WithMany()
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IngredienteAlimento_Ingrediente"),
                    l => l.HasOne<Alimento>().WithMany()
                        .HasForeignKey("IdAlimento")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IngredienteAlimento_Alimento"),
                    j =>
                    {
                        j.HasKey("IdAlimento", "IdIngrediente");
                        j.ToTable("IngredienteAlimento");
                    });
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("pk_idIngrediente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
