
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Application.InputModels;

namespace ResTIConnect.Application.Services
{
    public class EnderecoService : IEnderecoService
    {

        private readonly ResTIConnectContext _context;
        public EnderecoService(ResTIConnectContext context)
        {
            _context = context;
        }
        public int Create(NewEnderecoInputModel endereco)
        {
            var novoEndereco = new Enderecos
            {
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Cidade = endereco.Cidade,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Estado = endereco.Estado,
                Cep = endereco.Cep,
                Pais = endereco.Pais
            };

            _context.Enderecos.Add(novoEndereco);
            _context.SaveChanges();

            return novoEndereco.EnderecoId;
        }
        private Enderecos GetByDbId(int id)
        {
            var _endereco = _context.Enderecos.Find(id);

            if (_endereco is null)
                throw new EnderecoNotFoundException();

            return _endereco;
        }
        public void Delete(int id)
        {
            _context.Enderecos.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public List<EnderecoViewModel> GetAll()
        {
            var enderecos = _context.Enderecos
               .Select(e => new EnderecoViewModel
               {
                   EnderecoId = e.EnderecoId,
                   Logradouro = e.Logradouro,
                   Numero = e.Numero,
                   Cidade = e.Cidade,
                   Complemento = e.Complemento,
                   Bairro = e.Bairro,
                   Estado = e.Estado,
                   Cep = e.Cep,
                   Pais = e.Pais
               })
               .ToList();

            return enderecos;
        }

        public EnderecoViewModel? GetById(int id)
        {
            var _endereco = GetByDbId(id);
            var enderecoViewModel = new EnderecoViewModel
            {
                EnderecoId = _endereco.EnderecoId,
                Logradouro = _endereco.Logradouro,
                Numero = _endereco.Numero,
                Cidade = _endereco.Cidade,
                Complemento = _endereco.Complemento,
                Bairro = _endereco.Bairro,
                Estado = _endereco.Estado,
                Cep = _endereco.Cep,
                Pais = _endereco.Pais
            };
            return enderecoViewModel;
        }

        public void Update(int id, NewEnderecoInputModel endereco)
        {

            var _endereco = GetByDbId(id);

            _endereco.Logradouro = endereco.Logradouro;
            _endereco.Numero = endereco.Numero;
            _endereco.Cidade = endereco.Cidade;
            _endereco.Complemento = endereco.Complemento;
            _endereco.Bairro = endereco.Bairro;
            _endereco.Estado = endereco.Estado;
            _endereco.Cep = endereco.Cep;
            _endereco.Pais = endereco.Pais;

            _context.Enderecos.Update(_endereco);
            _context.SaveChanges();
        }
    }
}