using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() :
           base("User não encontrado.")
        {
        }
    }

}
