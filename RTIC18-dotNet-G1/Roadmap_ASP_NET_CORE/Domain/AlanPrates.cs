using System.Text;

namespace Semana1.Domain
{
      public static class AlanPrates
      {
            public static int TotalEstrelas;
            public static string Name => "Alan Prates";
            public static List<(string, int)> Skills => new List<(string, int)>
        {
            ("Desenvolvimento Web", 4),
            ("C#", 2),
            ("Trabalho em Equipe", 3)
        };

            public static string ListarHabilidades()
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

        public static object View()
        {
            throw new NotImplementedException();
        }
    }
}
