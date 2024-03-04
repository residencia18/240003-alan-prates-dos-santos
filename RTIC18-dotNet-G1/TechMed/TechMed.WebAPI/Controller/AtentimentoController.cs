using Microsoft.AspNetCore.Mvc;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controller;

[Route("Atendimento")]

[ApiController]
public class AtendimentoControler: ControllerBase
{
    protected IAtendimentoService _atendimentoService;
    protected List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
    public AtendimentoControler(IAtendimentoService service){
        _atendimentoService = service;
    }


    [HttpGet ("Atenditmento/all")]
    public IActionResult GetAll(){
        if (Atendimentos is not null)
            return Ok(Atendimentos);

        return NotFound();
    }

    [HttpGet ("Atendimento/{id}")]

    public IActionResult GetById(int id){
        var _atendimento = _atendimentoService.GetById(id);
                if (_atendimento is null)
            return NotFound();
        
        return Ok(_atendimento);
    }

    [HttpPost ("Atendimento/New")]
    public IActionResult Create(AtendimentoInputModel atendimento){
        var id = _atendimentoService.Create(atendimento);
        if (id > 0)
            return Ok(id);

        return BadRequest();
    }

    [HttpGet ("Atendimentos/Medico/{id}")]
    public IActionResult AtendimentoGetByIdMedico(int id){
        var atendimentosMedicos = Atendimentos.Where(a => a.Medico.MedicoId == id).ToList();
        if (atendimentosMedicos is null) return NotFound();
       
        return Ok(atendimentosMedicos);   
    }

    [HttpGet ("Atendimentos/Paciente/{id}")]
    public IActionResult AtendimentoGetByIdPaciente(int id){
        var atendimentoPacientes = Atendimentos.Where(a => a.Paciente.PacienteId == id).ToList();

        if (atendimentoPacientes is null) return NotFound();

        return Ok(atendimentoPacientes);
    }

    [HttpGet ("Atendimentos/Exame/{id}")]
    public IActionResult AtendimentoaGetByIdExame(int id){
        var atendimentosExame = Atendimentos.Where(a => a.Exames.Any(e => e.ExameId == id)).ToList();
        if (atendimentosExame is null) return NotFound();

        return Ok(atendimentosExame);
    }
}


