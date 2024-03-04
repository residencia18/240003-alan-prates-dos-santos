using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class SistemaController : ControllerBase
    {
        
        private readonly ISistemaService _sistemaService;
        public List<SistemaViewModel> Sistemas => _sistemaService.GetAll();
        public SistemaController(ISistemaService sistemaService) => _sistemaService = sistemaService;

        [HttpGet("sistemas")]
        [Authorize]
        public IActionResult Get()
        {

            return Ok(Sistemas);
        }
        [HttpGet("sistema/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var sistema = _sistemaService.GetById(id);
            return Ok(sistema);
        }
        

        [HttpPost("sistema")]
        [Authorize]
        public IActionResult Post([FromBody] NewSistemaInputModel sistema)
        {
            _sistemaService.Create(sistema);

            return CreatedAtAction(nameof(Get), sistema);

        }
        [HttpGet("system/user/{id}")]// – sistemas com alguma relação com um determinado usuário 
        [Authorize]
        public IActionResult GetSistemasByUserId(int userId)
        {
            var sistemas = _sistemaService.GetUserById(userId);
            return Ok(sistemas);
        }
        
        [HttpGet("system/event/{type}/from/{date}")]//  – sistemas onde ocorreram um determinado evento a partir de uma data até a atual 
        public IActionResult GetSistemasByEventoTipoByData(String tipo, DateTime dataInicio)
        {

            var sistemas = _sistemaService.GetByEventoPeriodos(tipo, dataInicio);
            return Ok(sistemas);
             
        }

        [HttpPut("evento/{eventoId}/sistema/{sistemaId}")]
        public IActionResult AdicionaSistemaAoEvento(int eventoId, int sistemaId)
        {
            try
            {
                _sistemaService.AdicionaSistemaAoEvento(eventoId, sistemaId);
                return Ok("Evento adicionado ao sistema com sucesso");
            }
            catch (EventoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SistemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

    }
}