using AutoMapper;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.EntitiesViews;

namespace Estacionamento.WebApi {
  public class MappingProfile : Profile {
    public MappingProfile () {

      CreateMap<CarroDomain, CarroViewModel> ().ReverseMap ();
      CreateMap<PessoaDomain, PessoaViewModel> ().ReverseMap ();
      CreateMap<ManobristaDomain, ManobristaViewModel> ().ReverseMap ();

    }
  }
}