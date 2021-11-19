using Estacionamento.Domain.Entities;
using Estacionamento.Repository.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Estacionamento.Repository.DataContext {

  public class EstacionamentoDataContext : DbContext {

      public EstacionamentoDataContext (DbContextOptions<EstacionamentoDataContext> options):
      base (options) {

      }

    public DbSet<CarroDomain> Carro { get; set; }
    public DbSet<PessoaDomain> Pessoa { get; set; }
    public DbSet<ManobristaDomain> Manobrista { get; set; }
 

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Ignore<Notification> ();
      modelBuilder.Ignore<Notifiable> ();
      modelBuilder.ApplyConfiguration (new CarroMap ());
      modelBuilder.ApplyConfiguration (new PessoaMap ());
      modelBuilder.ApplyConfiguration (new ManobristaMap ());

      base.OnModelCreating (modelBuilder);
    }
  }

}