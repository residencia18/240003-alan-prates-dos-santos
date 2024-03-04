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
    public class EventosController : ControllerBase
    {
        
        private readonly IEventoService _eventoService;
        public List<EventoViewModel> Eventos => _eventoService.GetAll();
        public EventosController(IEventoService eventoService) => _eventoService = eventoService;

        [HttpGet("eventos")]
        [Authorize]
        public IActionResult Get()
        {

            return Ok(Eventos);
        }
        [HttpGet("evento/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var evento = _eventoService.GetById(id);
            return Ok(evento);
        }
        

        [HttpPost("evento")]
        [Authorize]
        public IActionResult Post([FromBody] NewEventoInputModel evento)
        {
            _eventoService.Create(evento);

            return CreatedAtAction(nameof(Get), evento);

        }

    }
}