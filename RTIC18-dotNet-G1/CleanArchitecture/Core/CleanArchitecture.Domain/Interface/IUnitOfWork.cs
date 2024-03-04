namespace CleanArchitecture.Domain.Interface{
    //codernar as operações de persistencia
    public interface IUnitOfWork
    {
        //salvar os dados
        Task Commit(CancellationToken cancellationToken);
    }
}
