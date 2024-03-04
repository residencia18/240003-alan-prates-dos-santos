using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.InputModels
{
    public class LoginInputModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}