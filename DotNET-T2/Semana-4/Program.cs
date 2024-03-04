
class ContaBancaria
{
    private decimal saldo;

    // Propriedade Saldo com lógica personalizada para evitar saldos negativos
    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo não pode ser negativo");
            }
            saldo = value;
        }
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria minhaConta = new ContaBancaria();

        try
        {
            // Solicita ao usuário para inserir o saldo desejado
            Console.Write("Digite o saldo inicial da conta: ");
            decimal saldoInicial = decimal.Parse(Console.ReadLine());

            // Tenta definir o saldo inserido
            minhaConta.Saldo = saldoInicial;

            // Exibe o saldo atual
            Console.WriteLine($"Saldo atual: {minhaConta.Saldo}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Valor inválido inserido. Certifique-se de inserir um número válido.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}

class Veiculo
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    // Propriedade somente leitura para calcular a idade do veículo
    public int IdadeVeiculo
    {
        get
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - Ano;
        }
    }
}

class Program
{
    static void Main()
    {
        // Cria uma instância da classe Veiculo
        Veiculo meuVeiculo = new Veiculo();

        // Interage com o usuário para obter informações do veículo
        Console.Write("Digite o modelo do veículo: ");
        meuVeiculo.Modelo = Console.ReadLine();

        Console.Write("Digite o ano do veículo: ");
        meuVeiculo.Ano = int.Parse(Console.ReadLine());

        Console.Write("Digite a cor do veículo: ");
        meuVeiculo.Cor = Console.ReadLine();

        // Exibe as informações do veículo no console
        Console.WriteLine("\nInformações do Veículo:");
        Console.WriteLine($"Modelo: {meuVeiculo.Modelo}");
        Console.WriteLine($"Ano: {meuVeiculo.Ano}");
        Console.WriteLine($"Cor: {meuVeiculo.Cor}");
        Console.WriteLine($"Idade do Veículo: {meuVeiculo.IdadeVeiculo} anos");
    }
}

class Aluno
{
    // Propriedades automáticas para o nome e a idade
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Construtor que inicializa as propriedades com valores padrão
    public Aluno()
    {
        Nome = "Sem Nome";
        Idade = 0;
    }
}

class Program
{
    static void Main()
    {
        // Cria uma instância da classe Aluno
        Aluno meuAluno = new Aluno();

        // Interage com o usuário para obter informações do aluno
        Console.Write("Digite o nome do aluno: ");
        meuAluno.Nome = Console.ReadLine();

        Console.Write("Digite a idade do aluno: ");
        // Lida com possíveis erros ao tentar converter a entrada do usuário para int
        if (int.TryParse(Console.ReadLine(), out int idade))
        {
            meuAluno.Idade = idade;
        }
        else
        {
            Console.WriteLine("Erro: A idade inserida não é um número válido.");
            return;
        }

        // Exibe as informações do aluno no console
        Console.WriteLine("\nInformações do Aluno:");
        Console.WriteLine($"Nome: {meuAluno.Nome}");
        Console.WriteLine($"Idade: {meuAluno.Idade} anos");
    }
}
class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public override string ToString()
    {
        return $"{Nome} - {Telefone}";
    }
}

class Agenda
{
    private Contato[] contatos;

    // Propriedade indexada para acessar os contatos pelo índice
    public Contato this[int index]
    {
        get { return contatos[index]; }
        set { contatos[index] = value; }
    }

    public Agenda(int capacidade)
    {
        contatos = new Contato[capacidade];
    }
}

class Program
{
    static void Main()
    {
        // Cria uma instância da classe Agenda com capacidade para 3 contatos
        Agenda minhaAgenda = new Agenda(3);

        // Interage com o usuário para adicionar contatos à agenda
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nAdicionando contato {i + 1}:");
            Console.Write("Digite o nome do contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do contato: ");
            string telefone = Console.ReadLine();

            // Cria um novo contato e atribui à propriedade indexada da agenda
            minhaAgenda[i] = new Contato { Nome = nome, Telefone = telefone };
        }

        // Exibe as informações dos contatos usando a propriedade indexada
        Console.WriteLine("\nInformações dos Contatos:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Contato {i + 1}: {minhaAgenda[i]}");
        }
    }
}
