using System.Text;
namespace ClassDaniel.Domain
{
    public static class Daniel{
        public static int TotalEstrelas;
        public static string Name => "Daniel Olivera da Silva";
         public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 4),
            ("Habilidades Gerais de Desenvolvimento", 4),
            ("Fundamentos de Banco de Dados", 4),
            ("Noções básicas do ASP.NET Core", 2),
            ("Injeção de dependência", 1),
            ("HTML", 4),
            ("Clientes API e comunicação", 2),
            ("CSS", 3),
            ("JavaScript", 3)
            
         };
         public static int TotalStar(){
                var sum = Skills.Sum(x => x.Item2);
                return sum;
         }
        public static string ViewProfile()
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