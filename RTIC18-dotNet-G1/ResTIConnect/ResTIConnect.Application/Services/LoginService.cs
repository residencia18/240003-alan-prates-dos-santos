using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;


namespace ResTIConnect.Application.Services;

public class LoginService : ILoginService
{
    private readonly IUserService _userService; //Contrado com os metodos de acesso aos usuarios
    private readonly IAuthService _authService; //Contrato com os metodos para acesso ao json da WebApi 
    public LoginService(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
    public LoginViewModel? Authenticate(LoginInputModel login)
    {
        
        string _token = ""; //token inicialmente vazio

        if (_userService.AutenticateUser(login.Email, login.Password))
        {
            _token = _authService.GenerateJwtToken(login.Email, login.Email); //Gera o token e atribui o valor dele
        }
        if (_token != "")//se tudo der certo retorna um novo login com o token
        {
            return new LoginViewModel
            {
                Username = login.Email,
                Token = _token
            };
        }
        return null;
    }
}  
    
