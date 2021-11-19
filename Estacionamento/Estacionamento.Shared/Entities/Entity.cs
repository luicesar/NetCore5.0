using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace Estacionamento.Shared.Entities {
    public abstract class Entity : Notifiable {
        [Key]
        public int ID { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Entity () {
            this.DataCriacao = DateTime.Now;
        }

        public void SetId (int ID) {
            this.ID = ID;
        }

    }
}