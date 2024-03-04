using Microsoft.AspNetCore.Mvc;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Application.Services.Interfaces;


[Route("Exame")]
[ApiController]
public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;

    public ExameController(IExameService exameService)
    {
        _exameService = exameService;
    }

    [HttpPost ("Exame/New/{atendimentoId}")]
    public IActionResult CreateExame(int atendimentoId, [FromBody] ExameInputModel exame)
    {
        var exameId = _exameService.Create(atendimentoId, exame);
        if (exameId > 0)
        {
            return Ok(exameId);
        }
        else
        {
            return BadRequest("Falha ao criar exame");
        }
    }

    [HttpGet ("Exame/GetAll")]
    public IActionResult GetAllExames()
    {
        var exames = _exameService.GetAll();
        return Ok(exames);
    }

    [HttpGet("Exame/{id}/Get")]
    public IActionResult GetExameById(int id)
    {
        var exame = _exameService.GetById(id);
        if (exame != null)
        {
            return Ok(exame);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("Exeme/{id}/Update")]
    public IActionResult UpdateExame(int id, [FromBody] ExameInputModel exame)
    {
        _exameService.Update(id, exame);
        return NoContent();
    }

    [HttpDelete("Exame/{id}/Delete")]
    public IActionResult DeleteExame(int id)
    {
        _exameService.Delete(id);
        return NoContent();
    }
}