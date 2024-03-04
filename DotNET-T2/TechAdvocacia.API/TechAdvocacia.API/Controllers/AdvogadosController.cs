using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AdvogadosController : ControllerBase
{
    private readonly IAdvogadoService _advogadoService;

    public AdvogadosController(IAdvogadoService advogadoService)
    {
        _advogadoService = advogadoService;
    }

    // GET: /Advogados
    [HttpGet]
    public IActionResult GetAll()
    {
        var advogados = _advogadoService.GetAllAdvogados();
        return Ok(advogados);
    }

    // GET: /Advogados/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var advogado = _advogadoService.GetAdvogadoById(id);
        if (advogado == null)
        {
            return NotFound();
        }
        return Ok(advogado);
    }

    // POST: /Advogados
    [HttpPost]
    public IActionResult Create([FromBody] Advogado advogado)
    {
        // Aqui você deve adicionar lógica para criar um novo advogado
        // Exemplo: _advogadoService.CreateAdvogado(advogado);
        return CreatedAtAction(nameof(GetById), new { id = advogado.Id }, advogado);
    }

    // PUT: /Advogados/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Advogado advogado)
    {
        // Aqui você deve adicionar lógica para atualizar um advogado
        // Exemplo: _advogadoService.UpdateAdvogado(id, advogado);
        return NoContent();
    }

    // DELETE: /Advogados/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // Aqui você deve adicionar lógica para deletar um advogado
        // Exemplo: _advogadoService.DeleteAdvogado(id);
        return NoContent();
    }
}

public class Advogado
{
    public object Id { get; internal set; }
}

public interface IAdvogadoService
{
   public int Id { get; set; }

    object GetAdvogadoById(int id);
    object GetAllAdvogados();
}
