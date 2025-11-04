using CleanArchaticture.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchaticture.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? IncludeProperties = null);
        T Get(Expression<Func<T, bool>> Filter = null, string? IncludeProperties = null);

        void Add(T Entity);
        void Remove(T Entity);
        void Update(T Entity);
       
    }
}
