using Estacionamento.Repository.Interfaces;
using Estacionamento.Shared.Entities;

namespace Estacionamento.Application.Interfaces {
  public interface IServiceBase<T> : IRepositoryBase<T> where T : Entity {

  }
}