
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ResTIConnectContext _context;
        public SistemaService(ResTIConnectContext context)
        {
            _context = context;
        }
        
        public int Create(NewSistemaInputModel sistema)
        {
            var _sistema = new Sistemas
            {
                Descricao = sistema.Descricao,
                Tipo = sistema.Tipo,
            };

            _context.Sistemas.Add(_sistema);
            _context.SaveChanges();

            return _sistema.SistemaId;
        }

        public List<SistemaViewModel> GetAll()
        {
            var sistemas = _context.Sistemas
                .Include(s => s.Users)
                .Include(s => s.Eventos)
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo,
                    Users = s.Users != null ? s.Users.Select(s => new UserViewModel
                    {
                        UserId = s.UserId,
                        Name = s.Name
                    }).ToList() : null,
                    Eventos = s.Eventos != null ? s.Eventos.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Codigo = e.Codigo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia,
                        Descricao = e.Descricao,
                        Tipo = e.Tipo
                    }).ToList() : null
                })
                .ToList();

            return sistemas;
        }

        public List<SistemaViewModel> GetByEventoPeriodos(string tipoEvento, DateTime inicio)
        {
            var sistemas = _context.Sistemas
            .Where(s => s.Eventos.Any(e => e.Tipo == tipoEvento && e.DataHoraOcorrencia>= inicio))
            .Select(s => new SistemaViewModel
            {
                SistemaId = s.SistemaId,
                Descricao = s.Descricao,
                Tipo = s.Tipo
            })
            .ToList();

            return sistemas;
        }

        public SistemaViewModel GetById(int id)
        {
            var _sistema = _context.Sistemas
                .Include(s => s.Users)
                .Include(s => s.Eventos)
                .FirstOrDefault(s => s.SistemaId == id);

            if (_sistema is null)
                throw new SistemaNotFoundException();


            var sistemaViewModel = new SistemaViewModel
            {
                SistemaId = _sistema.SistemaId,
                Descricao = _sistema.Descricao,
                Tipo = _sistema.Tipo,
                    Users = _sistema.Users != null ? _sistema.Users.Select(s => new UserViewModel
                    {
                        UserId = s.UserId,
                        Name = s.Name
                    }).ToList() : null,
                    Eventos = _sistema.Eventos != null ? _sistema.Eventos.Select(e => new EventoViewModel
                    {
                        EventoId = e.EventoId,
                        Codigo = e.Codigo,
                        DataHoraOcorrencia = e.DataHoraOcorrencia,
                        Descricao = e.Descricao,
                        Tipo = e.Tipo
                    }).ToList() : null
            };
            return sistemaViewModel;

        }

        public List<SistemaViewModel> GetUserById(int userId)
        {
            var sistemas = _context.Sistemas
                .Where(s => s.Users!.Any(u => u.UserId == userId))
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo
                })
                .ToList();

            return sistemas;
        }
        public void AdicionaSistemaAoEvento(int EventoId, int sistemaId)
        {
            var _evento = _context.Eventos.Find(EventoId);
            if (_evento is null)
                throw new EventoNotFoundException();

            var _sistema = _context.Sistemas.Find(sistemaId);
            if (_sistema is null)
                throw new SistemaNotFoundException();

            _evento.Sistemas!.Add(_sistema);
            _context.SaveChanges();
        }
    }
}
