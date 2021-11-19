using System;
using System.Collections.Generic;
using Estacionamento.Domain.Entities;
using System.Text.Json.Serialization;
using Estacionamento.Domain.Models;

namespace Estacionamento.Domain.EntitiesViews {
  public class PessoaViewModel : Model<PessoaDomain> {

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }

    [JsonIgnore]
    public ICollection<ManobristaDomain> Manobristas { get; private set; }
  }
}