using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core
{
    public abstract class DbRepository<TContext> : IDisposable
      where TContext : DbContext
    {
        private TContext _context;

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAllQuery<TEntity>()
            where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllQueryWithInclude<TEntity>(params Expression<Func<TEntity, object>>[] actions)
            where TEntity : class
        {
            DbSet<TEntity> dbSet = Context.Set<TEntity>();

            IQueryable<TEntity> result = dbSet;
            foreach (var action in actions)
            {
                result = result.Include(action);
            }

            return result;
        }

        public IQueryable<TEntity> GetQueryType<TEntity>()
            where TEntity : class
        {
            // all query types should be marked with the IQueryType in order to collect their data
            return Context.Query<TEntity>();
        }

        public void Delete<TEntity>(TEntity entityToBeRemoved)
            where TEntity : class
        {
            Context.Set<TEntity>().Remove(entityToBeRemoved);
            Save<TEntity>(Context);
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entitiesToBeDeleted)
            where TEntity : class
        {
            Context.RemoveRange(entitiesToBeDeleted);
            Save<TEntity>(Context);
        }

        public TEntity Insert<TEntity>(TEntity entityToBeInserted)
            where TEntity : class
        {
            Context.Set<TEntity>().Add(entityToBeInserted);
            Save<TEntity>(Context);
            return entityToBeInserted;
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entitiesToBeInserted)
            where TEntity : class
        {
            Context.Set<TEntity>().AddRange(entitiesToBeInserted);
            Save<TEntity>(Context);
        }

        public TEntity Update<TEntity>(TEntity entityToBeUpdated)
            where TEntity : class
        {
            Context.Set<TEntity>().Update(entityToBeUpdated);
            Save<TEntity>(Context);
            return entityToBeUpdated;
        }

        public IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entitiesToBeUpdated)
            where TEntity : class
        {
            Context.UpdateRange(entitiesToBeUpdated);
            Save<TEntity>(Context);
            return entitiesToBeUpdated;
        }

        protected abstract TContext CreateDbContextObject();

        protected TContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = CreateDbContextObject();
                }

                return _context;
            }
        }

        private void Save<TEntity>(TContext context)
            where TEntity : class
        {
            context.SaveChanges();
            DetachEntities<TEntity>(context);
        }

        private void DetachEntities<TEntity>(TContext context)
            where TEntity : class
        {
            context.Set<TEntity>().Local.ToList().ForEach(c =>
            {
                context.Entry(c).State = EntityState.Detached;
            });
        }
    }
}
