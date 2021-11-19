using Estacionamento.Domain.Entities;
using Estacionamento.Repository.DataContext;
using Estacionamento.Repository.Interfaces;
using Estacionamento.Application.Interfaces;

namespace Estacionamento.Application.Services {
  public class ManobristaService : ServiceBase<ManobristaDomain>, IManobristaService {
    public ManobristaService (EstacionamentoDataContext dbContext, IManobristaRepository categoria) : base (dbContext) {

    }
  }
}