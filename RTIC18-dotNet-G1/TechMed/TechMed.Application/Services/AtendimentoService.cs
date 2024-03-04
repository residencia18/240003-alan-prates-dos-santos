using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;

using TechMed.Application.Services;
using TechMed.Application.Services.Interfaces;

using TechMed.Dommain.Entities;
using TechMed.Infrastructure.Context;

namespace TechMed.Application.Service;


public class AtendimentoService : BaseService, IAtendimentoService
{
    protected readonly IMedicoService _medicoService;
    protected readonly IPacienteService _pacienteService;
    protected readonly IExameService _exameService;
    

    public AtendimentoService(TechMedContext context, IMedicoService medicoService, IPacienteService pacienteService,IExameService exameService) : base(context)
    {
        _medicoService = medicoService;
        _pacienteService = pacienteService;
        _exameService = exameService;
    } //Passas o contexto 

    public List<AtendimentoViewModel> GetAll()
    {


        var _atendimentos = _context.Atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Medico = new MedicoViewModel { MedicoId = a.MedicoId, Nome = a.Medico.Nome, CRM = a.Medico.CRM },
            Paciente = new PacienteViewModel { PacienteId = a.PacienteId, Nome = a.Paciente.Nome },

        }).ToList();


        return _atendimentos;
    }

   
   
    public AtendimentoViewModel GetById(int id)
    {

        var _atendimento = _context.Atendimentos.FirstOrDefault(a => a.AtendimentoId == id);
        if (_atendimento is null) return null!;
        var medico = _medicoService.GetById(_atendimento.MedicoId);
        if (medico is null) return null!;
        var paciente = _pacienteService.GetById(_atendimento.PacienteId);
        if (paciente is null) return null!;
        // var exames = _examesService.GetByAtendimentoId(_atendimento.AtendimentoId);
        if (_atendimento is not null)
        {
            var atendimento = new AtendimentoViewModel{
                AtendimentoId = _atendimento.AtendimentoId,
                Medico = medico!,
                Paciente = paciente!,
                DataHoraFim = _atendimento.DataHoraFim,
                SuspeitaInicial = _atendimento.SuspeitaInicial,
            };
            return atendimento;
        }
        return null!;

    }

    public int Create(AtendimentoInputModel _newAtendimento)
    {
        var id = _context.Atendimentos.Count() > 0 ? _context.Atendimentos.Max(m => m.AtendimentoId) + 1 : 1;
        var medico = _context.Medicos.Find(_newAtendimento.MedicoId);
        var paciente = _context.Pacientes.Find(_newAtendimento.PacienteId);

        if (medico is not null && paciente is not null)
        {
            var _atendimento = new Atendimento
            {
                AtendimentoId = id,
                PacienteId = paciente.PacienteId,
                Paciente = paciente,
                MedicoId = medico.MedicoId,
                Medico = medico,
                DataHoraInicio = DateTimeOffset.Now,
                SuspeitaInicial = _newAtendimento.SuspeitaInicial,
            };
            _context.Atendimentos.Add(_atendimento);
            _context.SaveChanges();

            return _atendimento.AtendimentoId;
        }
        return 0;
    }

    public void Delete(int id)
    {
        var _atendimento = _context.Atendimentos.Find(id);
        if(_atendimento is null) return;

        _context.Atendimentos.Remove(_atendimento);
        
    }


    public void Update(int id, AtendimentoInputModel Entity)
    {
        var _atendimento = _context.Atendimentos.Find(id);

        return;
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        throw new NotImplementedException();
    }

}