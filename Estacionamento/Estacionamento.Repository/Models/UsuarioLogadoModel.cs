using System;
using System.Collections.Generic;
using Estacionamento.Domain.Entities;

namespace Estacionamento.Repository.Models {
  public class UsuarioLogadoModel {
    public string UID { get; set; }
    public DateTime DataExpiracao { get; set; }
    public UsuarioLogadoModel () { }

  }
}