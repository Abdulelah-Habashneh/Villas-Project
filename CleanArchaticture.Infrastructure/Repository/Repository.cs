using CleanArchaticture.Application.Common.Interfaces;
using CleanArchaticture.Domain.Model;
using CleanArchaticture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchaticture.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext context)
        {
            _context=context;
            DbSet = _context.Set<T>();
        }



        public void Add(T Entity)
        {
            DbSet.Add(Entity);
        }

       

        public T Get(Expression<Func<T, bool>> Filter = null, string? IncludeProperties = null)
        {
            IQueryable<T> Query = DbSet;
            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }

            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeprop in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeprop);
                }
            }

            return Query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? IncludeProperties = null)
        {
            IQueryable<T> Query = DbSet;
            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }

            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var includeprop in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeprop);
                }
            }

                return Query.ToList();
        }

        public void Remove(T Entity)
        {
            DbSet.Remove(Entity);
        }
 

        public void Update(T Entity)
        {
            DbSet.Update(Entity);

        }

       

    }
}
