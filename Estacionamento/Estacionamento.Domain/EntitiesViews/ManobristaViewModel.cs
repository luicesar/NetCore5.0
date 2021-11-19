using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Models;

namespace Estacionamento.Domain.EntitiesViews {
  public class ManobristaViewModel : Model<ManobristaDomain> {
    public int PessoaId { get; set; }
    public int CarroId { get; set; }
  }
}