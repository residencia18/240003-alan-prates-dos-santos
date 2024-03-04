
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Security;


namespace ResTIConnect.Application.Services
{
    public class UserService : IUserService
    {

        private readonly ResTIConnectContext _context;
        public UserService(ResTIConnectContext context)
        {
            _context = context;
        }



        public List<UserViewModel> GetAll()
        {
            var users = _context.Users
                .Include(u => u.Endereco)
                .Include(u => u.Sistemas)
                .Include(u => u.Perfis)
                .Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Endereco = u.Endereco != null ? new EnderecoViewModel
                    {
                        EnderecoId = u.Endereco.EnderecoId,
                        Logradouro = u.Endereco.Logradouro,
                        Numero = u.Endereco.Numero,
                        Cidade = u.Endereco.Cidade,
                        Complemento = u.Endereco.Complemento,
                        Bairro = u.Endereco.Bairro,
                        Estado = u.Endereco.Estado,
                        Cep = u.Endereco.Cep,
                        Pais = u.Endereco.Pais
                    } : null,
                    Sistemas = u.Sistemas != null ? u.Sistemas.Select(s => new SistemaViewModel
                    {
                        SistemaId = s.SistemaId,
                        Descricao = s.Descricao,
                        Tipo = s.Tipo
                    }).ToList() : null,
                    Perfis = u.Perfis != null ? u.Perfis.Select(p => new PerfilViewModel
                    {
                        PerfilId = p.PerfilId,
                        Descricao = p.Descricao,
                        Permissoes = p.Permissoes
                    }).ToList() : null
                })
                .ToList();

            return users;
        }

        public int Create(NewUserInputModel user)
        {
             var passwordHash = Utils.HashPassword(user.Password);
            var _user = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = passwordHash,
                EnderecoId = user.EnderecoId,
            };

            _context.Users.Add(_user);

            _context.SaveChanges();

            return _user.UserId;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public UserViewModel? GetById(int id)
        {
            var _user = GetByDbId(id);

            if (_user is null)
                throw new UserNotFoundException();

            var userViewModel = new UserViewModel
            {
                UserId = _user.UserId,
                Name = _user.Name,
                Endereco = _user.Endereco != null ? new EnderecoViewModel
                {
                    EnderecoId = _user.Endereco.EnderecoId,
                    Logradouro = _user.Endereco.Logradouro,
                    Numero = _user.Endereco.Numero,
                    Cidade = _user.Endereco.Cidade,
                    Complemento = _user.Endereco.Complemento,
                    Bairro = _user.Endereco.Bairro,
                    Estado = _user.Endereco.Estado,
                    Cep = _user.Endereco.Cep,
                    Pais = _user.Endereco.Pais
                } : null,
                Perfis = _user.Perfis != null ? _user.Perfis.Select(p => new PerfilViewModel
                {
                    PerfilId = p.PerfilId,
                    Descricao = p.Descricao,
                    Permissoes = p.Permissoes
                }).ToList() : null,
                Sistemas = _user.Sistemas != null ? _user.Sistemas.Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo
                }).ToList() : null
            };

            return userViewModel;
        }

        public List<UserViewModel> GetBySistemaId(int id)
        {
           var users = _context.Users
            .Where(u => u.Sistemas!.Any(s => s.SistemaId == id))
            .Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Name = u.Name,
            })
            .ToList();

            return users;
        }

        public List<UserViewModel> GetByPerfilId(int perfilId)
        {
           var users = _context.Users
            .Where(u => u.Perfis!.Any(s => s.PerfilId == perfilId))
            .Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Name = u.Name,
            })
            .ToList();

            return users;
        }


        private User GetByDbId(int id)
        {
            var _user = _context.Users.Find(id);

            if (_user is null)
                throw new UserNotFoundException();

            return _user;
        }
        public void Update(int id, NewUserInputModel user)
        {
            var passwordHash = Utils.HashPassword(user.Password);
            var _user = GetByDbId(id);
            _user.Name = user.Name!;
            _user.EnderecoId = user.EnderecoId;
            _user.Password = passwordHash;
            _context.Users.Update(_user);
            _context.SaveChanges();
        }

        public bool AutenticateUser(string email, string password)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == Utils.HashPassword(password));

            if (_user is null)
                return false;

            return (_user.Email == email);
        }
        public void AdicionaSistemaAoUser(int userId, int sistemaId)
        {
            var _user = GetByDbId(userId);
            if (_user is null)
                throw new UserNotFoundException();

            var _sistema = _context.Sistemas.Find(sistemaId);
            if (_sistema is null)
                throw new SistemaNotFoundException();

            _user.Sistemas!.Add(_sistema);
            _context.SaveChanges();
            
        }


        public List<UserViewModel> GetByEnderecoUF(string uf)
        {
            
           var users = _context.Users
            .Where(u => u.Endereco!.Estado == uf)
            .Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Name = u.Name,
            })
            .ToList();

            return users;
        }

        public void AdicionaPerfilAoUser(int userId, int perfilId)
        {
            
            var _user = GetByDbId(userId);
            if (_user is null)
                throw new UserNotFoundException();

            var _perfil = _context.Perfis.Find(perfilId);
            if (_perfil is null)
                throw new SistemaNotFoundException();

            _user.Perfis!.Add(_perfil);
            _context.SaveChanges();
        }

    }
}