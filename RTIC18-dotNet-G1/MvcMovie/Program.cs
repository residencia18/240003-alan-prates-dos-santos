using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcMovieContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext"));
    }
    else
    {
        // TODO: Configuração para ambiente de produção (ex: MySQL)
    }
});

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "ListagemArtista",
    pattern: "User/ListagemArtista",
    defaults: new { controller = "User", action = "ListagemArtista" }
);


app.MapControllerRoute(
    name: "ListagemEstudio",
    pattern: "User/ListagemEstudio",
    defaults: new { controller = "User", action = "ListagemEstudio" }
);
app.MapControllerRoute(
    name: "Painel",
    pattern: "User/Painel",
    defaults: new { controller = "User", action = "Painel" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();