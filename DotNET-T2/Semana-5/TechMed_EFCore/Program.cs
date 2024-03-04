using TechMed_EFCore.Models;

var context = new TechMedContext();
Console.WriteLine($"Lendo todos os medicos no banco de dados");
foreach (var med in context.Medicos.OrderBy(m =>m.Nome))
{
    Console.WriteLine($"Id: {med.Id} - Nome: {med.Nome} - CRM: {med.Crm}");
}
Console.WriteLine($"Lendo todos os pacientes no banco de dados");
foreach (var pac in context.Pacientes.OrderBy(m => m.Nome))
{
    Console.WriteLine($"Id: {pac.Id} - Nome: {pac.Nome} - CRM: {pac.Cpf}");
}

Console.WriteLine($"Criar medico no banco de dados");

var medico = new Medico{

    Cpf = "12345678901",
    Crm = "123456",
    Especialidade = "Cardiologista",
    Nome = "Alan Prates",
    Salario = 2000
};
context.Medicos.Add(medico);
Console.WriteLine($"Adicionando um novo paciente no banco de dados");

var paciente = new Paciente{
    Cpf = "12345678901",
    Nome = "Alan Prates",
    Endereco = "Rua das laranjeiras, 123",
    Telefone  = "123456789"
};
context.Pacientes.Add(paciente);

context.SaveChanges();

Console.WriteLine($"Atualizando o nome do paciente no banco de dados");
var doente = context.Pacientes.Where(p => p.Cpf == "12345678901").FirstOrDefault();
doente.Nome = "Cida";
context.Pacientes.Update(doente);

context.SaveChanges();

Console.WriteLine($"Removendo o primeiro medico  no banco de dados");
var primeiroMedico = context.Medicos.FirstOrDefault();
context.Medicos.Remove(primeiroMedico);

context.SaveChanges();
Console.WriteLine($"Finalizando programa");

/*  context.Medicos.Add(new Medico
{
    Cpf = "12345678901",
    Crm = "123456",
    Especialidade = "Cardiologista",
    Nome = "Alan Prates",
    Salario = 2000
});

context.SaveChanges();
 */

/* context.Medicos.ToList().ForEach(m => Console.WriteLine($"{m.Id} - {m.Nome} - {m.Crm} - {m.Especialidade} - {m.Salario}"));
 */
