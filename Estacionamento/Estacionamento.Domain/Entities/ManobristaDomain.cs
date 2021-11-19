using Estacionamento.Shared.Entities;
using Flunt.Validations;

namespace Estacionamento.Domain.Entities {
    public class ManobristaDomain : Entity {

        protected ManobristaDomain () {

        }

        public ManobristaDomain (int pessoaId, int carroId) {

            PessoaId = pessoaId;
            CarroId = carroId;

            AddNotifications (new Contract ()
                .Requires ()
                .IsGreaterThan (PessoaId, 0, "Manobrista.PessoaId", "Informe uma pessoa.")
                .IsGreaterThan (CarroId, 0, "Manobrista.CarroId", "Informe um carro.")
            );
        }

        public int PessoaId { get; set; }
        public PessoaDomain Pessoa { get; set; }
        public int CarroId { get; set; }
        public CarroDomain Carro { get; set; }
    }
}