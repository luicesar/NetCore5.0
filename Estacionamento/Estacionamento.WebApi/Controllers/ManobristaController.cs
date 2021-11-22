using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Domain.Entities;
using Estacionamento.Domain.EntitiesViews;
using Estacionamento.Application.Interfaces;
using Estacionamento.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.WebApi.Controllers {
    [Authorize ("Bearer"), Route ("api/[controller]")]
    // [Route ("api/[controller]")]
    public class ManobristaController : ControllerBase<ManobristaDomain, ManobristaViewModel> {
        private readonly IManobristaService Service;
        public ManobristaController (IManobristaService service) : base (service) {
            this.Service = service;
        }

        [HttpGet, Route ("ListaComCarroPessoa")]
        public IEnumerable<ManobristaSlimViewModel> GetManobristasCarroPessoa () {

            var lista = new List<ManobristaSlimViewModel> ();

            var manobristas = new List<ManobristaDomain> ();
            manobristas = Service.GetAll (null, i => i.Carro, i => i.Pessoa).ToList ();

            foreach (var item in manobristas) {

                var view = new ManobristaSlimViewModel {
                    ID = item.ID,
                    CarroId = item.CarroId,
                    MarcaNome = item.Carro.Marca,
                    ModeloNome = item.Carro.Modelo,
                    PessoaId = item.PessoaId,
                    PessoaNome = item.Pessoa.Nome
                };

                lista.Add (view);
            }

            return lista;
        }
    }
}