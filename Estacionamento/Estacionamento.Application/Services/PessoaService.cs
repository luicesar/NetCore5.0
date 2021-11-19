using Estacionamento.Domain.Entities;
using Estacionamento.Repository.DataContext;
using Estacionamento.Repository.Interfaces;
using Estacionamento.Application.Interfaces;

namespace Estacionamento.Application.Services {
  public class PessoaService : ServiceBase<PessoaDomain>, IPessoaService {
    public PessoaService (EstacionamentoDataContext dbContext, IPessoaRepository categoria) : base (dbContext) {

    }
  }
}