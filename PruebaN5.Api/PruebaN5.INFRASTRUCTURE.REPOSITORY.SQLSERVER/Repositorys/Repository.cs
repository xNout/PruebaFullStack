using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PruebaN5.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly N5DBContext context;
        protected readonly DbSet<TEntity> Entity;
        public Repository(DbContext context)
        {
            this.context = (N5DBContext)context;
            this.Entity = context.Set<TEntity>();
        }
        
        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await Entity.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity?> GetAsync(int id)
        {
            return await Entity.FindAsync(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
