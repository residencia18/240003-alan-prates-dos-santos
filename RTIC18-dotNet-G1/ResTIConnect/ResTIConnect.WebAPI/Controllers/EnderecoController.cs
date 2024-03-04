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
    public class EnderecoController: ControllerBase
    {
        
        
        private readonly IEnderecoService _enderecoService;
        public List<EnderecoViewModel> Enderecos => _enderecoService.GetAll();
        public EnderecoController(IEnderecoService service) => _enderecoService = service;


        [HttpGet("enderecos")]
        [Authorize]

        public IActionResult Get()
        {
            return Ok(Enderecos);
        }

        [HttpGet("endereco/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var endereco = _enderecoService.GetById(id);
            return Ok(endereco);
        }


        [HttpPost("endereco")]
        [Authorize]
        public IActionResult Post([FromBody] NewEnderecoInputModel endereco)
        {
            _enderecoService.Create(endereco);

            return CreatedAtAction(nameof(Get), endereco);

        }

        [HttpPut("endereco/{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] NewEnderecoInputModel endereco)
        {
            if (_enderecoService.GetById(id) == null)
                return NoContent();
            _enderecoService.Update(id, endereco);
            return Ok(_enderecoService.GetById(id));
        }

        [HttpDelete("endereco/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (_enderecoService.GetById(id) == null)
                return NoContent();
            _enderecoService.Delete(id);
            return Ok();
        }
    }
}