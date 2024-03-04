
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Exceptions
{
    public class EventoNotFoundException: Exception
    {
        public EventoNotFoundException() :
           base("Evento não encontrado.")
        {
        }
    }
}