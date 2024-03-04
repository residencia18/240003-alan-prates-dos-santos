
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;

namespace TechMed.Application.Services.Interfaces{
    public interface IMedicoService
    {
        
      public List<MedicoViewModel> GetAll();
      public MedicoViewModel? GetById(int id);
      public MedicoViewModel? GetByCrm(string crm);
      public int Create(MedicoInputModel medico);
      public void Update(int id, MedicoInputModel medico);
      public void Delete(int id);
    }
}