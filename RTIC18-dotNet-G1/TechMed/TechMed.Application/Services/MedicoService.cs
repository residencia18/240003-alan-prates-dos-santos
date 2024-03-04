
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;
using TechMed.Application.Services;
using TechMed.Application.Services.Interfaces;
using TechMed.Dommain.Entities;
using TechMed.Infrastructure.Context;

namespace TechMed.Application.Service;

public class MedicoService: BaseService, IMedicoService
{
    public MedicoService(TechMedContext context) : base(context){} //pasando o contexto para o construtor da classe base

    public int Create(MedicoInputModel medico)
    {
        var id = _context.Medicos.Count() > 0 ? _context.Medicos.Max(m => m.MedicoId) + 1 : 1;
        var _medico = new Medico{
            MedicoId = id,
            CRM = id.ToString(),
            Nome = medico.Nome!
        };

        _context.Medicos.Add(_medico);

        _context.SaveChanges();

        return _medico.MedicoId;

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    
    public List<MedicoViewModel> GetAll()
    {
       var _medicos = _context.Medicos.Select(m => new MedicoViewModel{
            MedicoId = m.MedicoId,
            Nome = m.Nome,
            CRM = m.CRM,

       });

       return _medicos.ToList();
    }

    public MedicoViewModel? GetByCrm(string crm)
    {
       var medico = _context.Medicos.FirstOrDefault(m => m.CRM == crm);
        if(medico is null) return null;
       return new MedicoViewModel { MedicoId = medico.MedicoId, Nome = medico.Nome };
    }

    public MedicoViewModel? GetById(int id)
    {
        var _medico = _context.Medicos.Find(id);
        if(_medico is not null){
            return new MedicoViewModel { MedicoId = _medico.MedicoId, Nome = _medico.Nome };
        }
        return null;
    }

    public void Update(int id, MedicoInputModel medico)
    {
        var _medico = _context.Medicos.Find(id);
        if (_medico is null) return;
        
        _medico.Nome = medico.Nome!;
        _medico.CRM = medico.CRM;
        _medico.UpdatedAt = DateTime.Now;
        _context.Medicos.Update(_medico);
        _context.SaveChanges();
    }
}