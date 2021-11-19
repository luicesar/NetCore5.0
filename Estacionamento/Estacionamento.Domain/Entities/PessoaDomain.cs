using System;
using System.Collections.Generic;
using Estacionamento.Shared.Entities;
using Flunt.Validations;

namespace Estacionamento.Domain.Entities {
    public class PessoaDomain : Entity {

        protected PessoaDomain () {
            Manobristas = new List<ManobristaDomain> ();
        }

        public PessoaDomain (string nome, string cpf, DateTime dataNascimento) {

            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;

            AddNotifications (new Contract ()
                .Requires ()
                .IsNotNullOrEmpty (Nome, "Pessoa.Nome", "O campo nome é obrigatório")
                .IsNotNullOrEmpty (Cpf, "Pessoa.Cpf", "O campo cpf é obrigatório")
            );
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<ManobristaDomain> Manobristas { get; private set; }
    }
}