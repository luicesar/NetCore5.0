using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Repository.Mapping {
  public class ManobristaMap : IEntityTypeConfiguration<ManobristaDomain> {
    public void Configure (EntityTypeBuilder<ManobristaDomain> builder) {
      builder.Property (t => t.ID).IsRequired ().HasColumnType ("int");
      builder.Property (t => t.DataCriacao).HasColumnType ("datetime");

      builder.ToTable ("Manobrista");
    }
  }
}