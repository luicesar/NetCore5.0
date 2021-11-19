using Estacionamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estacionamento.Repository.Mapping {
  public class PessoaMap : IEntityTypeConfiguration<PessoaDomain> {
    public void Configure (EntityTypeBuilder<PessoaDomain> builder) {
      builder.Property (t => t.ID).IsRequired ().HasColumnType ("int");
      builder.Property (t => t.Nome).IsRequired ().HasColumnType ("varchar(100)");
      builder.Property (t => t.Cpf).IsRequired ().HasColumnType ("varchar(20)");
      builder.Property (t => t.DataNascimento).IsRequired ().HasColumnType ("datetime");
      builder.Property (t => t.DataCriacao).HasColumnType ("datetime");

      builder.HasMany (x => x.Manobristas).WithOne (x => x.Pessoa)
        .HasForeignKey (x => x.PessoaId)
        .HasPrincipalKey (x => x.ID);

      builder.ToTable ("Pessoa");
    }
  }
}