using Grouper.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Grouper.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.DbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);

            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<System.Linq.IQueryable<T>, System.Linq.IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (query != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            query = query?.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = DbSet.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}