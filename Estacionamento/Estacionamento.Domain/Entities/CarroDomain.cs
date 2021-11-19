using System.Collections.Generic;
using Estacionamento.Shared.Entities;
using Flunt.Validations;

namespace Estacionamento.Domain.Entities {
    public class CarroDomain : Entity {

        protected CarroDomain () {
            Manobristas = new List<ManobristaDomain> ();
        }

        public CarroDomain (string marca, string modelo, string placa) {

            Marca = marca;
            Modelo = modelo;
            Placa = placa;

            AddNotifications (new Contract ()
                .Requires ()
                .IsNotNullOrEmpty (Marca, "Carro.Marca", "O campo marca é obrigatório")
                .IsNotNullOrEmpty (Modelo, "Carro.Marca", "O campo modelo é obrigatório")
                .IsNotNullOrEmpty (Placa, "Carro.Marca", "O campo placa é obrigatório")
            );
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public ICollection<ManobristaDomain> Manobristas { get; private set; }
    }
}