namespace TechMed.Dommain.Exceptions;
public class AtendimentoNotFoundException : Exception
{
   public AtendimentoNotFoundException() :
      base("Atendimento não encontrado")
   {
   }
}
