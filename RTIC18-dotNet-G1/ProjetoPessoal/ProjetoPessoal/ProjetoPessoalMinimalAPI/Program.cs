var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); // Pegar rota e mandar essa mensagem
// Posso ter várias rotas, os endpoints

app.Run();
