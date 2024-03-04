using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace Semana1.Domain
{
    public static class Lorena
    {

        public static int TotalEstrelas;
        public static string Name => "Lorena Andrade";
        public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 5),
            ("Habilidades Gerais de Desenvolvimento", 4),
            ("Fundamentos de Banco de Dados", 4),
            ("Noções básicas do ASP.NET Core", 2),
            ("Injeção de dependência", 1),
            ("Estruturas de log", 1),
            ("Clientes API e comunicação", 1),
            ("Comunicação em tempo real", 1),
            ("Agendamento de tarefas", 1),
            ("Teste", 1),
            ("Microsserviços", 1)
         };
        public static string View()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine();
            sb.AppendLine("Habilidades:");
            foreach (var skill in Skills)
            {
                sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
            }
            var sum = Skills.Sum(x => x.Item2);
            TotalEstrelas = sum;

            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sum}");
            return sb.ToString();
        }
    }
}