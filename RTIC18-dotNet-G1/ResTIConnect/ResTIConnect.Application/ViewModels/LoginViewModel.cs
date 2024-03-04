using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.ViewModels
{
    public class LoginViewModel
    {
        public required string Username { get; set; }
        public required string Token { get; set; }
    }
}