
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
    public class EventoService : IEventoService
    {
        
        private readonly ResTIConnectContext _context;

        public EventoService(ResTIConnectContext context)
        {
            _context = context;
        }
        public int Create(NewEventoInputModel evento)
        {
            var _evento = new Eventos
            {
                Descricao = evento.Descricao,
                Tipo = evento.Tipo,
                Codigo = evento.Codigo,
                Conteudo = evento.Conteudo,
                DataHoraOcorrencia = evento.DataHoraOcorrencia
            };

            _context.Eventos.Add(_evento);
            _context.SaveChanges();

            return _evento.EventoId;
        }

        public List<EventoViewModel> GetAll()
        {
           var eventos = _context.Eventos
                .Include(e => e.Sistemas)
                .Select(e => new EventoViewModel
                {
                    EventoId = e.EventoId,
                    Tipo = e.Tipo,
                    Descricao = e.Descricao,
                    Codigo = e.Codigo,
                    Conteudo = e.Conteudo,
                    DataHoraOcorrencia = e.DataHoraOcorrencia
                })
                .ToList();

            return eventos;
        }

        public EventoViewModel? GetById(int id)
        {
             var evento = _context.Eventos
                .Include(e => e.Sistemas)
                .FirstOrDefault(e => e.EventoId == id);

            if (evento == null)
                throw new EventoNotFoundException();

            var eventoViewModel = new EventoViewModel
            {
                EventoId = evento.EventoId,
                Tipo = evento.Tipo,
                Descricao = evento.Descricao,
                Codigo = evento.Codigo,
                Conteudo = evento.Conteudo,
                DataHoraOcorrencia = evento.DataHoraOcorrencia
            };

            return eventoViewModel;
        }
    }
}