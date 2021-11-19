using System.Collections.Generic;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.Models;
using System.Text.Json.Serialization;

namespace Estacionamento.Domain.EntitiesViews {
  public class CarroViewModel : Model<CarroDomain> {

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }

    [JsonIgnore]
    public ICollection<ManobristaDomain> Manobristas { get; private set; }
  }
}