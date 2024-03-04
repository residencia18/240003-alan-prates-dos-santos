using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;

namespace ResTIConnect.WebAPI.Controllers
{
    public class LoginController: ControllerBase
    {
        
        private readonly ILoginService _loginService;
        public LoginController(ILoginService service)
        {
            _loginService = service;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginInputModel login)
        {
            var result = _loginService.Authenticate(login);
            if (result is not null)
                return Ok(result);
            else
                return BadRequest("Usuário ou senha inválidos");
        }
    }
}