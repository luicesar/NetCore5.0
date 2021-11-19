using Estacionamento.Shared.Entities;

namespace Estacionamento.Domain.Models {
  public interface IModel<D> where D : Entity {
    D MapForDomain ();
  }
}