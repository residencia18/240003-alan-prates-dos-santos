using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;

namespace TechMed.Application.Services.Interfaces
{
    public interface IAtendimentoService
    {
        public List<AtendimentoViewModel> GetAll();
        public AtendimentoViewModel? GetById(int id);
    
        public int Create(AtendimentoInputModel atendimento);
        public void Delete(int id);
        public void Update(int id, AtendimentoInputModel Entity);
    }
}