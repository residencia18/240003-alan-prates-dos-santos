
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
  public interface IUserService
  {

    public List<UserViewModel> GetAll();
    public UserViewModel? GetById(int id);
    public List<UserViewModel> GetByEnderecoUF(string uf);
    public List<UserViewModel> GetBySistemaId(int sistemaId);
    public List<UserViewModel> GetByPerfilId(int perfilId);
    public int Create(NewUserInputModel user);
    public bool AutenticateUser(string email, string password);
      public void AdicionaSistemaAoUser(int userId, int sistemaId);
    public void AdicionaPerfilAoUser(int userId, int sistemaId);
    public void Update(int id, NewUserInputModel user);
    public void Delete(int id);

  }
}