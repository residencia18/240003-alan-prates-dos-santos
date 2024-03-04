using System;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interface{
    //repositorio generico
    // T significa o tipo de dado no nosso caso T é o tipo BaseEntity
    public interface IBaseRepository<T> where T: BaseEntity{
        
        //void Create(T entity): Esse método é responsável por criar um novo objeto do tipo T e adicioná-lo à fonte de dados correspondente, como uma tabela ou uma base de dados.
        void Create(T entity);

        //void Update(T entity): Esse método é responsável por atualizar um objeto do tipo T existente na fonte de dados
        void Update(T entity);

        //void Delete(T entity): Esse método é responsável por remover um objeto do tipo T existente na fonte de dados
        void Delete(T entity);

        //A função Get retorna uma Task<T>, onde T é um tipo genérico. Essa tarefa permite obter um objeto do tipo T com base no parâmetro id do tipo Guide. 
        Task<T> Get(Guid id, CancellationToken cancellationToken);// o Cancellation Token serve para parar o processo de busca de dados caso precise cancelar
        //A assinatura do método Get indica que ele pode ser usado para obter um objeto de qualquer tipo. O tipo do objeto a ser retornado é especificado pelo tipo genérico T na declaração do método.
        
        Task<List<T>> GetAll(CancellationToken cancellationToken);
       // A função GetAll retorna uma Task<List<T>>, onde T é um tipo genérico. Essa tarefa permite obter uma lista de objetos do tipo T. 
    }
}