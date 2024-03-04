using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Domain.Common;

namespace  ResTIConnect.Domain.Entities
{
    public class Sistemas : BaseEntity
    {
        public int SistemaId { get; set; }

        public required string Descricao { get; set; }

        public string? Tipo { get; set; }

        public string? EnderecoEntrada { get; set; }

        public string? EnderecoSaida { get; set; }

        public string? Protocolo { get; set; }

        public DateTimeOffset DataHoraInicioIntegracao { get; set; }

        public string? Status { get; set; }

        public ICollection<User>? Users { get; set; } = new List<User>();

        public ICollection<Eventos>? Eventos { get; set; } = new List<Eventos>();
    }
}