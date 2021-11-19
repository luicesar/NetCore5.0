using Estacionamento.Repository;
using Estacionamento.Repository.DataContext;
using Estacionamento.Application.Interfaces;
using Estacionamento.Shared.Entities;

namespace Estacionamento.Application {
  public class ServiceBase<T> : RepositoryBase<T>, IServiceBase<T> where T : Entity {
    public ServiceBase (EstacionamentoDataContext dbContext) : base (dbContext) { }

  }
}