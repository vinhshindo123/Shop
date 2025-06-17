using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Infrastructure.Data;

namespace Shop.Infrastructure.Respositories
{
    public class Respository<T> : IReporitory<T> where T : class
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Respository(ShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity) => await _context.AddAsync(entity);
        public void UpdateAsync(T entity) => _dbSet.Update(entity);
        public void DeleteAsync(T entity) => _dbSet.Remove(entity);
        public async Task<T?> GetReporitoryAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllReporitoryAsync() => await _dbSet.ToListAsync();
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
