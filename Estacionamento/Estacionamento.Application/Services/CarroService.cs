using Estacionamento.Domain.Entities;
using Estacionamento.Repository.DataContext;
using Estacionamento.Repository.Interfaces;
using Estacionamento.Application.Interfaces;

namespace Estacionamento.Application.Services {
  public class CarroService : ServiceBase<CarroDomain>, ICarroService {
    public CarroService (EstacionamentoDataContext dbContext, ICarroRepository categoria) : base (dbContext) {

    }
  }
}