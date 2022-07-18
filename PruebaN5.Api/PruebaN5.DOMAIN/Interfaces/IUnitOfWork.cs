using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task SaveChanges();
        ITipoPermisoRepository tipoPermisoRepository { get; }
        IPermisosRepository permisosRepository { get; }
    }
}
