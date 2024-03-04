
using System.Data;

namespace CleanArchitecture.Domain.Entities 
{
    public abstract class BaseEntity{ //Uma entidade base para as demais entidade como regra explicta
        // Um Guide  é um indentificador da entidade base, base de todos os guides
        public Guid Id {get; set;}
        //Data e hora de criação
        public DateTimeOffset Created {get; set;} 
        //Data e hora de atualização caso os dados tenha sido atualizados
        public DateTimeOffset? Updated {get; set;}
        //Data e hora de exclusão
        public DateTimeOffset? Deleted {get; set;}
    }

}
