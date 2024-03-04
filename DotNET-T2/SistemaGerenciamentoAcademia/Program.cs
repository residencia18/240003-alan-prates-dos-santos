using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

public class Treinador : Pessoa
{
    public string CREF { get; set; }
}

public class Cliente : Pessoa
{
    public double Altura { get; set; }
    public double Peso { get; set; }

    // Método para calcular o IMC
    public double CalcularIMC()
    {
        // Ajustando a fórmula do IMC para considerar altura em metros e peso em quilogramas
        return Peso / Math.Pow(Altura, 2);
    }

    // Método para exibir o IMC
    public void ExibirIMC()
    {
        double imc = CalcularIMC();
        Console.WriteLine($"IMC de {Nome}: {imc.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}

public class Academia
{
    public List<Treinador> Treinadores { get; set; }
    public List<Cliente> Clientes { get; set; }

    public Academia()
    {
        Treinadores = new List<Treinador>();
        Clientes = new List<Cliente>();
    }

    // Métodos para validações
    private bool ValidarDataNascimento(DateTime dataNascimento)
    {
        // Adicione aqui a lógica de validação desejada para a data de nascimento
        // Por exemplo, pode verificar se a data não está no futuro.
        return dataNascimento <= DateTime.Now;
    }

    private bool ValidarCPF(string cpf)
    {
        // Adicione aqui a lógica de validação desejada para o CPF
        // Por exemplo, pode verificar o formato do CPF.
        return !string.IsNullOrEmpty(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit);
    }

    // Métodos para adicionar treinador e cliente com validações
    public void AdicionarTreinador(Treinador treinador)
    {
        if (ValidarDataNascimento(treinador.DataNascimento) && ValidarCPF(treinador.CPF))
        {
            Treinadores.Add(treinador);
            Console.WriteLine("Treinador adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Dados inválidos. Treinador não adicionado.");
        }
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (ValidarDataNascimento(cliente.DataNascimento) && ValidarCPF(cliente.CPF) && cliente.Altura > 0 && cliente.Peso > 0)
        {
            Clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");

            // Agora, após atribuir os valores de altura e peso, chamamos o método ExibirIMC
            cliente.ExibirIMC();
        }
        else
        {
            Console.WriteLine("Dados inválidos. Cliente não adicionado.");
        }
    }

    public List<Treinador> TreinadoresEntreIdades(int idadeMinima, int idadeMaxima)
    {
        DateTime dataLimiteSuperior = DateTime.Now.AddYears(-idadeMinima);
        DateTime dataLimiteInferior = DateTime.Now.AddYears(-idadeMaxima);

        return Treinadores.Where(t => t.DataNascimento >= dataLimiteInferior && t.DataNascimento <= dataLimiteSuperior).ToList();
    }

    public List<Cliente> ClientesEntreIdades(int idadeMinima, int idadeMaxima)
    {
        DateTime dataLimiteSuperior = DateTime.Now.AddYears(-idadeMinima);
        DateTime dataLimiteInferior = DateTime.Now.AddYears(-idadeMaxima);

        return Clientes.Where(c => c.DataNascimento >= dataLimiteInferior && c.DataNascimento <= dataLimiteSuperior).ToList();
    }

    public List<Cliente> ClientesComIMCMaiorQue(double valor)
    {
        return Clientes.Where(c => c.CalcularIMC() > valor).OrderBy(c => c.CalcularIMC()).ToList();
    }

    public List<Cliente> ClientesEmOrdemAlfabetica()
    {
        return Clientes.OrderBy(c => c.Nome).ToList();
    }

    public List<Cliente> ClientesDoMaisVelhoParaOMaisNovo()
    {
        return Clientes.OrderByDescending(c => c.DataNascimento).ToList();
    }

    public List<Pessoa> AniversariantesDoMes(int mes)
    {
        return Treinadores.Cast<Pessoa>().Concat(Clientes.Cast<Pessoa>()).Where(p => p.DataNascimento.Month == mes).ToList();
    }
}

class Program
{
    static Academia academia = new Academia();

    static void Main()
    {
        int opcao;
        do
        {
            MostrarMenu();

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                ExecutarOpcao(opcao);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

        } while (opcao != 0);
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1. Adicionar Treinador");
        Console.WriteLine("2. Adicionar Cliente");
        Console.WriteLine("3. Relatório: Treinadores entre idades");
        Console.WriteLine("4. Relatório: Clientes entre idades");
        Console.WriteLine("5. Relatório: Clientes com IMC maior que");
        Console.WriteLine("6. Relatório: Clientes em ordem alfabética");
        Console.WriteLine("7. Relatório: Clientes do mais velho para o mais novo");
        Console.WriteLine("8. Relatório: Aniversariantes do mês");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void ExecutarOpcao(int opcao)
    {
        switch (opcao)
        {
            case 1:
                AdicionarTreinador();
                break;
            case 2:
                AdicionarCliente();
                break;
            case 3:
                RelatorioTreinadoresEntreIdades();
                break;
            case 4:
                RelatorioClientesEntreIdades();
                break;
            case 5:
                RelatorioClientesComIMCMaiorQue();
                break;
            case 6:
                RelatorioClientesEmOrdemAlfabetica();
                break;
            case 7:
                RelatorioClientesDoMaisVelhoParaOMaisNovo();
                break;
            case 8:
                RelatorioAniversariantesDoMes();
                break;
            case 0:
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void AdicionarTreinador()
    {
        Treinador treinador = new Treinador();

        Console.Write("Nome: ");
        treinador.Nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            treinador.DataNascimento = dataNascimento;
        }
        else
        {
            Console.WriteLine("Data de nascimento inválida.");
            return;
        }

        Console.Write("CPF: ");
        try
        {
            treinador.CPF = Console.ReadLine();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.Write("CREF: ");
        treinador.CREF = Console.ReadLine();

        academia.AdicionarTreinador(treinador);
    }

    static void AdicionarCliente()
    {
        Cliente cliente = new Cliente();

        Console.Write("Nome: ");
        cliente.Nome = Console.ReadLine();

        Console.Write("Data de Nascimento (dd/mm/aaaa): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            cliente.DataNascimento = dataNascimento;
        }
        else
        {
            Console.WriteLine("Data de nascimento inválida.");
            return;
        }

        Console.Write("CPF: ");
        try
        {
            cliente.CPF = Console.ReadLine();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.Write("Altura (metros): ");
        if (double.TryParse(Console.ReadLine(), out double altura))
        {
            cliente.Altura = altura;
        }
        else
        {
            Console.WriteLine("Altura inválida.");
            return;
        }

        Console.Write("Peso (kg): ");
        if (double.TryParse(Console.ReadLine(), out double peso))
        {
            cliente.Peso = peso;
        }
        else
        {
            Console.WriteLine("Peso inválido.");
            return;
        }

        academia.AdicionarCliente(cliente);
    }

    static void RelatorioTreinadoresEntreIdades()
    {
        Console.Write("Idade mínima: ");
        if (int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.Write("Idade máxima: ");
            if (int.TryParse(Console.ReadLine(), out int idadeMaxima))
            {
                List<Treinador> treinadores = academia.TreinadoresEntreIdades(idadeMinima, idadeMaxima);

                Console.WriteLine("\nTreinadores entre as idades especificadas:");
                foreach (var treinador in treinadores)
                {
                    Console.WriteLine($"{treinador.Nome} - Data de Nascimento: {treinador.DataNascimento.ToShortDateString()} - CREF: {treinador.CREF}");
                }
            }
            else
            {
                Console.WriteLine("Idade máxima inválida.");
            }
        }
        else
        {
            Console.WriteLine("Idade mínima inválida.");
        }
    }

    static void RelatorioClientesEntreIdades()
    {
        Console.Write("Idade mínima: ");
        if (int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.Write("Idade máxima: ");
            if (int.TryParse(Console.ReadLine(), out int idadeMaxima))
            {
                List<Cliente> clientes = academia.ClientesEntreIdades(idadeMinima, idadeMaxima);

                Console.WriteLine("\nClientes entre as idades especificadas:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
                }
            }
            else
            {
                Console.WriteLine("Idade máxima inválida.");
            }
        }
        else
        {
            Console.WriteLine("Idade mínima inválida.");
        }
    }

    static void RelatorioClientesComIMCMaiorQue()
    {
        Console.Write("Valor do IMC mínimo: ");
        if (double.TryParse(Console.ReadLine(), out double valorMinimo))
        {
            List<Cliente> clientes = academia.ClientesComIMCMaiorQue(valorMinimo);

            Console.WriteLine("\nClientes com IMC maior que o valor especificado:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nome} - IMC: {cliente.CalcularIMC():F2}");
            }
        }
        else
        {
            Console.WriteLine("Valor do IMC inválido.");
        }
    }

    static void RelatorioClientesEmOrdemAlfabetica()
    {
        List<Cliente> clientes = academia.ClientesEmOrdemAlfabetica();

        Console.WriteLine("\nClientes em ordem alfabética:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
        }
    }

    static void RelatorioClientesDoMaisVelhoParaOMaisNovo()
    {
        List<Cliente> clientes = academia.ClientesDoMaisVelhoParaOMaisNovo();

        Console.WriteLine("\nClientes do mais velho para o mais novo:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome} - Data de Nascimento: {cliente.DataNascimento.ToShortDateString()} - CPF: {cliente.CPF}");
        }
    }

    static void RelatorioAniversariantesDoMes()
    {
        Console.Write("Número do mês (1 a 12): ");
        if (int.TryParse(Console.ReadLine(), out int mes))
        {
            List<Pessoa> aniversariantes = academia.AniversariantesDoMes(mes);

            Console.WriteLine($"\nAniversariantes do mês {mes}:");
            foreach (var pessoa in aniversariantes)
            {
                Console.WriteLine($"{pessoa.Nome} - Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine("Número do mês inválido.");
        }
    }
}
