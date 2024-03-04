namespace CleanArchitecture.Domain.Entities{
    //o uso do sealed restringe a herança, ou seja significa que essa clases user não pode ser herdada
    public sealed class User : BaseEntity
    {
        public required string Email {get; set;} //uso do required para dizer que o email é obrigatório
        public string? Name {get; set;} //uso do ? para dizer que o name pode ser nulo

        //Herdando todos esses outros atributos da minha classe BaseEntity
        // public abstract class BaseEntity{ //Uma entidade base para as demais entidade como regra explicta
        //     // Um Guide  é um indentificador da entidade base, base de todos os guides
        //     public Guid Id {get; set;}; 
        //     //Data e hora de criação
        //     public DateTimeOffset Created {get; set;} 
        //     //Data e hora de atualização caso os dados tenha sido atualizados
        //     public DateTimeOffset? Updated {get; set;}
        //     //Data e hora de exclusão
        //     public DateTimeOffset? Deleted {get; set;}
        // }
    }

}


