using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Repository.Mapping {
  public class CarroMap : IEntityTypeConfiguration<CarroDomain> {
    public void Configure (EntityTypeBuilder<CarroDomain> builder) {
      builder.Property (t => t.ID).IsRequired ().HasColumnType ("int");
      builder.Property (t => t.Marca).IsRequired ().HasColumnType ("varchar(100)");
      builder.Property (t => t.Modelo).IsRequired ().HasColumnType ("varchar(100)");
      builder.Property (t => t.Placa).IsRequired ().HasColumnType ("varchar(10)");
      builder.Property (t => t.DataCriacao).HasColumnType ("datetime");

      builder.HasMany (x => x.Manobristas).WithOne (x => x.Carro)
        .HasForeignKey (x => x.CarroId)
        .HasPrincipalKey (x => x.ID);

      builder.ToTable ("Carro");
    }
  }
}