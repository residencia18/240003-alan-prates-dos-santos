using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace ResTIConnect.WebAPI.Controllers
{
    
    [ApiController]
    [Route("/api/v0.1/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public List<UserViewModel> Users => _userService.GetAll();
        public UserController(IUserService service) => _userService = service;


        [HttpGet("users")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        [HttpGet("user/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }


        [HttpPost("user")]
        [Authorize]
        public IActionResult Post([FromBody] NewUserInputModel user)
        {
            _userService.Create(user);

            return CreatedAtAction(nameof(Get), user);

        }

        [HttpPut("user/{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] NewUserInputModel user)
        {
            if (_userService.GetById(id) == null)
                return NoContent();
            _userService.Update(id, user);
            return Ok(_userService.GetById(id));
        }

        [HttpDelete("user/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (_userService.GetById(id) == null)
                return NoContent();
            _userService.Delete(id);
            return Ok();
        }
        
        [HttpGet("users/perfil/{id}")]//  – usuários com um determinado perfil 
        [Authorize]
        public IActionResult GetUsersByPerfilId(int perfilId)
        {
             var user = _userService.GetByPerfilId(perfilId);
            return Ok(user);
        }

        [HttpGet("users/sistema/{id}")]//  – usuários com um determinado sistema 
        [Authorize]
        public IActionResult GetUsersBySistemaId(int sistemaId)
        {
            var user = _userService.GetBySistemaId(sistemaId);
            return Ok(user);
        }

        [HttpGet("users/address/{uf}")]//  – usuários de um determinado estado 
        [Authorize]
        public IActionResult GetUsersByAddressUF(string uf)
        {
            var user = _userService.GetByEnderecoUF(uf);
            return Ok(user);
        }
        
        [HttpPut("user/{userId}/sistema/{sistemaId}")]
        [Authorize]
        public IActionResult AdicionaSistemaAoUser(int userId, int sistemaId)
        {
            try
            {
                _userService.AdicionaSistemaAoUser(userId, sistemaId);
                return Ok("Sistema adicionado ao usuário com sucesso");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SistemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
        
        [HttpPut("user/{userId}/perfil/{perfilId}")]
        [Authorize]
        public IActionResult AdicionaPerfilAoUser(int userId, int perfilId)
        {
            try
            {
                _userService.AdicionaPerfilAoUser(userId, perfilId);
                return Ok("Perfil adicionado ao usuário com sucesso");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SistemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
    }
}