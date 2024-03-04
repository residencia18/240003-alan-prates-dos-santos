using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Exceptions
{
    public class PerfilNotFoundException: Exception
    {
        public PerfilNotFoundException() :
           base("Perfil não encontrado.")
        {
        }
    }
}