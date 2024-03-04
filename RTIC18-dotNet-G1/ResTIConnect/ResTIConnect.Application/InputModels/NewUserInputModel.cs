using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application
{
    public class NewUserInputModel
    {
         public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int EnderecoId { get; set; }
    }
}