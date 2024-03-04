using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Configuration
{
    public Configuration(IConfiguration configuration)
    {
        ConfigurationSettings = configuration;
    }

    public IConfiguration ConfigurationSettings { get; }

    // Este método é chamado pelo runtime. Use este método para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configurações dos serviços
    }

    // Este método é chamado pelo runtime. Use este método para configurar o pipeline de solicitações HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configurações do pipeline
    }
    
}
