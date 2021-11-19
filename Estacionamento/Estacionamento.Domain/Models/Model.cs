using System;
using AutoMapper;
using Estacionamento.Shared.Entities;

namespace Estacionamento.Domain.Models {
  public abstract class Model<T> : IModel<T> where T : Entity {
    public int ID { get; set; }
    public DateTime DataCriacao { get; set; }

    public virtual T MapForDomain () {
      return Mapper.Map<T> (this);
    }
  }
}