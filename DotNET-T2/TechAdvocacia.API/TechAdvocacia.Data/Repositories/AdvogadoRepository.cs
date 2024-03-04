// TechAdvocacia.Data/Repositories/AdvogadoRepository.cs
using System.Collections.Generic;
using TechAdvocacia.Core.Models;
using TechAdvocacia.Data.Context;

public class AdvogadoRepository : IAdvogadoRepository
{
    private readonly AdvocaciaContext _context;

    public AdvogadoRepository(AdvocaciaContext context)
    {
        _context = context;
    }

    public IEnumerable<Advogado> GetAll()
    {
        return _context.Advogados;
    }

    // Implementação de outros métodos CRUD...
}
