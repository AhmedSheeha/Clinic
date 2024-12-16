using System.Linq.Expressions;
using Clinic.Repositories.IRepos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
            if(item !=  null) _context.Set<T>().Add(item);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> DbSetQuery = _context.Set<T>();
            if(filter != null) DbSetQuery = DbSetQuery.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    DbSetQuery = DbSetQuery.Include(item);
                }
            }
            return await DbSetQuery.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> query, string? includeProperties = null)
        {
            IQueryable<T> DbSet = _context.Set<T>();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    DbSet = DbSet.Include(item);
                }
            }
            return await DbSet.FirstOrDefaultAsync(query);
        }

        public async Task Remove(T item)
        {
            _context.Set<T>().Remove(item);
        }
    }
}
