using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.ViewModel;
using TechMed.Aplication.InputModel;
namespace TechMed.Aplication.Services.Interfaces
{
    public interface IPacienteService
    {
      
      public List<PacienteViewModel> GetAll();
      public PacienteViewModel? GetById(int id);
      public int Create(PacienteInputModel paciente);
      public void Update(int id, PacienteInputModel paciente);
      public void Delete(int id);
    }
}