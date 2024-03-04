namespace ResTIConnect.Application.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role); 
    }
}
