using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ResTIConnect.WebAPI.Controllers
{
    
    [ApiController]
    [Route("/api/v0.1/")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;
        public List<PerfilViewModel> Perfis => _perfilService.GetAll();
        public PerfilController(IPerfilService service) => _perfilService = service;


        [HttpGet("perfis")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(Perfis);
        }

        [HttpGet("perfil/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var perfil = _perfilService.GetById(id);
            return Ok(perfil);
        }


        [HttpPost("perfil")]
        [Authorize]
        public IActionResult Post([FromBody] NewPerfilInputModel perfil)
        {
            _perfilService.Create(perfil);

            return CreatedAtAction(nameof(Get), perfil);

        }

        [HttpPut("perfil/{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] NewPerfilInputModel perfil)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Update(id, perfil);
            return Ok(_perfilService.GetById(id));
        }

        [HttpDelete("perfil/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (_perfilService.GetById(id) == null)
                return NoContent();
            _perfilService.Delete(id);
            return Ok();
        }
    }
}