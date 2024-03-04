
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;
namespace TechMed.Application.Services.Interfaces;
public interface IExameService
{
    int Create(int AtendimentoId, ExameInputModel exame);
    void Delete(int id);
    public List<ExameViewModel> GetAll();
    public ExameViewModel GetById(int id);
    void Update(int id, ExameInputModel exame);

}