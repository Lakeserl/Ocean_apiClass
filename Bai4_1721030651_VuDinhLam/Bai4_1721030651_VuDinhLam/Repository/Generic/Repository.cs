using AutoMapper;
using Bai4_1721030651_VuDinhLam.Data;
using Bai4_1721030651_VuDinhLam.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bai4_1721030651_VuDinhLam.Repository.Generic
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetListAsync();
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> MaxIdAsync(int id);
        Task<int> MinIdAsync(int id);

    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiteachingContext _context;
        public Repository(ApiteachingContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<int> MaxIdAsync(int id)
        {
            return await _context.Set<T>().MaxAsync(e => EF.Property<int>(e, "Id"));
        }

        public async Task<int> MinIdAsync(int id)
        {
            return await _context.Set<T>().MinAsync(e => EF.Property<int>(e, "Id"));
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
