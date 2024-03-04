using System.Text;


namespace Semana1.Domain
{
    public static class Caua
    {

        public static int TotalEstrelas;
        public static string Name => "Caua Clemente";
        public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 4),
            ("Habilidades Gerais de Desenvolvimento", 3),
            ("Fundamentos de Banco de Dados", 2),
            ("Noções básicas do ASP.NET Core", 3),
            ("C#",3),
            ("Git",4)
         };
        public static string View()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Nome: {Name}"+"\n");
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