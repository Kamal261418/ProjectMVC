using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly MVCAppGr03DbContext context;

        public GenaricRepository(MVCAppGr03DbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(T item)
        {
            context.Set<T>().Add(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            context.Set<T>().Remove(item);
            return await context.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
        => await context.Set<T>().FindAsync(id);


        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T)  == typeof(Employee))
                return (IEnumerable<T>) await context.Set<Employee>().Include(E => E.Department).ToListAsync();
            else    
            return await context.Set<T>().ToListAsync();

        }
        public async Task<int> Update(T item)
        {
            context.Set<T>().Update(item);
            return await context.SaveChangesAsync();
        }

    }
}
