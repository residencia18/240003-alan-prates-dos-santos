using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Exceptions
{
    public class SistemaNotFoundException: Exception
    {
        public SistemaNotFoundException() :
           base("Sistema não encontrado.")
        {
        }
    }
}