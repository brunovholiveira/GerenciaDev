using GDev.Business.Interfaces;
using GDev.Business.Model;
using GDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GDev.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDBContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApplicationDBContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
                
        public async Task<IEnumerable<Entity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> BuscarPorId(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity objeto)
        {
            DbSet.Add(objeto);
            await SaveChanges();
        }

        public virtual async Task Alterar(TEntity objeto)
        {
            Db.Update(objeto);
            await SaveChanges();
        }

        public virtual async Task Excluir(Guid Id)
        {
            DbSet.Remove(new TEntity { Id = Id });
            await SaveChanges();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        
        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
}
