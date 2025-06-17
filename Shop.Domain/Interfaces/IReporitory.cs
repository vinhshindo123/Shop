using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure;

namespace Shop.Domain.Interfaces
{
    public interface IReporitory<T> where T : class
    {
        Task<T?> GetReporitoryAsync(int id);
        Task<IEnumerable<T>> GetAllReporitoryAsync();
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
