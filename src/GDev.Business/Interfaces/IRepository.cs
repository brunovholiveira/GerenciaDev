using GDev.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GDev.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity 
    {
        Task<IEnumerable<TEntity>> BuscarTodos();
        Task<TEntity> BuscarPorId(Guid Id);
        Task<IEnumerable<Entity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task Adicionar(TEntity objeto);
        Task Excluir(Guid Id);
        Task Alterar(TEntity objeto);
        Task<int> SaveChanges();
    }
}
