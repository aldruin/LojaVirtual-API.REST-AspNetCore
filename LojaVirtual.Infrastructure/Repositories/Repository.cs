using LojaVirtual.Domain.Abstractions;
using LojaVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(LojaVirtualDbContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return Query.AnyAsync(expression);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await Query.FindAsync(id);
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            try
            {
                var consulta = await Query.ToListAsync();
                return consulta;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
