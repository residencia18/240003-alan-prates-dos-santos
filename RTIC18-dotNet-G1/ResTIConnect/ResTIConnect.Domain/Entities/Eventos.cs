using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Domain.Common;

namespace ResTIConnect.Domain.Entities
{
    public class Eventos: BaseEntity
{
    public int EventoId { get; set; }
    public string? Tipo { get; set; }
    public required string Descricao { get; set; }
    public string? Codigo { get; set; }
    public string? Conteudo { get; set; }
    public DateTimeOffset DataHoraOcorrencia { get; set; }
    public ICollection<Sistemas>? Sistemas { get; set; } = new List<Sistemas>();
}
}
