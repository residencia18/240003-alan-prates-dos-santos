using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace ResTIConnect.Application.Services;

public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(string Name, string Email)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));//cria uma chave utilizando criptografia simétrica
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//cria as credenciais do token

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, Name),
                new Claim(ClaimTypes.Email, Email)
            };
            var token = new JwtSecurityToken( //cria o token
               issuer: issuer, //emissor do token
               audience: audience, //destinatário do token
               claims: claims, //informações do usuário
               expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
               signingCredentials: credentials); //credenciais do token
            var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
