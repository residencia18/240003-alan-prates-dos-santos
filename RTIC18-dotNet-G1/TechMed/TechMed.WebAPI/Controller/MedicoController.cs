using Microsoft.AspNetCore.Mvc;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controller;

[Route("Medico")]
[ApiController]

public class MedicoContoller : ControllerBase
{

    protected readonly IMedicoService? _medicoService;
    public List<MedicoViewModel> Medicos => _medicoService.GetAll();

    public MedicoContoller(IMedicoService service)
    {
        _medicoService = service;
    }

    [HttpGet("Medico/All")]
    public ActionResult GetAll()
    {
        return Ok(Medicos);
    }

    [HttpGet("Medico/{id}")]
    public ActionResult GetById(int id)
    {
        var _medico = _medicoService.GetById(1);
        if (_medico is null)
        {
            return NotFound();
        }
        return Ok(_medico);
    }

    [HttpPost("Medico/New")]
    public ActionResult Create(MedicoInputModel medico)
    {
        _medicoService.Create(medico);
        return Ok();

    }

    [HttpDelete("Medico/{id}/Delete")]
    public ActionResult Delete(int id)
    {
        _medicoService.Delete(id);
        return Ok();
    }

}
