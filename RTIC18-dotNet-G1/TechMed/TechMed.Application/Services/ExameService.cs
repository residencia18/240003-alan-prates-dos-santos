namespace TechMed.Application.Services;
using System.Collections.Generic;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;
using TechMed.Application.Services.Interfaces;
using TechMed.Dommain.Entities;
using TechMed.Infrastructure.Context;

public class ExameService : BaseService, IExameService
{


    public ExameService(TechMedContext context) : base(context){}

    public int Create(int AtendimentoId, ExameInputModel exame)
    {

        var _atendimento = _context.Atendimentos.Find(AtendimentoId);
        var _id = _context.Exames.Count() > 0 ? _context.Exames.Max(e => e.ExameId) + 1 : 1;
        if (_atendimento is null) return 0;
        var _exame = new Exame
        {
            ExameId = _id,
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Local = exame.Local,
            Atendimentos = new List<Atendimento>
            {
                _atendimento
            }
           
        };

        _context.Exames.Add(_exame);
       
        _context.SaveChanges();
        return _exame.ExameId;
    }



    public void Delete(int id)
    {
        var exame = _context.Exames.Find(id);
        if (exame is not null)
        {
            _context.Exames.Remove(exame);
        }
    }

    public List<ExameViewModel> GetAll()
    {
        var exames = _context.Exames.Select(e => new ExameViewModel
        {
            ExameId = e.ExameId,
            ExameNome = e.Nome,
            DataHora = e.DataHora,
            ResultadoDescricao = e.ResultadoDescricao,
            Local = e.Local,

        }).ToList();

        return exames;
    }


    public ExameViewModel GetById(int id)
    {
        var exame = _context.Exames
            .Where(e => e.ExameId == id)
            .Select(e => new ExameViewModel
            {
                ExameId = e.ExameId,
                ExameNome = e.Nome,
                DataHora = e.DataHora,
                ResultadoDescricao = e.ResultadoDescricao,
                Local = e.Local
            })
            .FirstOrDefault();
            if (exame is null) return null!;

        return exame;
    }

    public void Update(int id, ExameInputModel entity)
    {
        var exame = _context.Exames.Find(id);
        if (exame != null)
        {
            exame.Nome = entity.Nome;
            exame.DataHora = entity.DataHora;
            exame.Valor = entity.Valor;
            exame.Local = entity.Local;

            _context.Exames.Update(exame);
            _context.SaveChanges();
        }
    }

}