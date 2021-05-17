using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jwt_api_boilerplate.Interfaces;
using jwt_api_boilerplate.Models;

namespace jwt_api_boilerplate.Services
{
    public sealed class APIService<T> : IService<T> where T : class
    {
        private readonly Context ctx;

        public APIService(Context ctx)
        {
            this.ctx = ctx;
        }

        public async Task<T> Get(int? id)
        {
            return await ctx.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await ctx.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T obj)
        {
            ctx.Set<T>().Add(obj);
            await ctx.SaveChangesAsync();

            return obj;
        }

        public async Task<T> Update(T obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            await ctx.SaveChangesAsync();

            return obj;
        }

        public async Task<T> Delete(int? id)
        {
            T obj = await Get(id);

            ctx.Entry(obj).State = EntityState.Deleted;
            await ctx.SaveChangesAsync();

            return obj;
        }
    }
}
