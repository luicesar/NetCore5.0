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
    //[Authorize ("Bearer"), Route ("api/[controller]")]
    [Route ("api/[controller]")]
    public class CarroController : ControllerBase<CarroDomain, CarroViewModel> {
        private readonly ICarroService Service;
        public CarroController (ICarroService service) : base (service) {
            this.Service = service;
        }
    }
}