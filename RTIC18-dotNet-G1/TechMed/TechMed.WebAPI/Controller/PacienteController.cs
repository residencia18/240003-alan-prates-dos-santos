
using Microsoft.AspNetCore.Mvc;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;


namespace TechMed.WebAPI.Controller;

[Route("Paciente")]
[ApiController]

public class PacienteController: ControllerBase
{
    protected readonly IPacienteService _pacienteService;
    public List<PacienteViewModel> Pacientes => _pacienteService.GetAll();
    public PacienteController(IPacienteService service){
        _pacienteService = service;
    }


    [HttpGet ("Paciente/All")]
    public IActionResult GetAll(){
        return Ok(Pacientes);
    }       

    [HttpPost ("Paciente/New")]
    public IActionResult Create(PacienteInputModel paciente){
        _pacienteService.Create(paciente);
        return Ok();
    }

    [HttpGet ("Pacientes/{id}")]
    public IActionResult GetById(int id){
        var _paciente = _pacienteService.GetById(id);
        if(_paciente is not null){
            return Ok(_pacienteService.GetById(id));
            
        }
        return NotFound();
    }

    [HttpDelete ("Paciente/Del/{id}")]
    public IActionResult Delete(int id){
        _pacienteService.Delete(id);
        return Ok();
    }
}
