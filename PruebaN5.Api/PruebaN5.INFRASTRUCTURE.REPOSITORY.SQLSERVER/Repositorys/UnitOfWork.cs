using Microsoft.EntityFrameworkCore.Storage;
using PruebaN5.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly N5DBContext context;
        private IDbContextTransaction? transaction;
        public IPermisosRepository permisosRepository { get; }
        public ITipoPermisoRepository tipoPermisoRepository { get; }
        public UnitOfWork(N5DBContext context)
        {
            this.context = context;
            this.permisosRepository = new PermisosRepository(context);
            this.tipoPermisoRepository = new TipoPermisoRepository(context);
        }
        public async Task BeginTransaction()
        {
            this.transaction = await context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransaction()
        {
            if (transaction is null)
                throw new Exception("Primero debes inicializar una transaccion antes de realizar un commit");

            await transaction.CommitAsync();
        }
        public async Task RollbackTransaction()
        {
            if (transaction is null)
                throw new Exception("Primero debes inicializar una transaccion antes de realizar un rollback");

            await transaction.RollbackAsync();
            await transaction.DisposeAsync();
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
