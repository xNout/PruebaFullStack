using Microsoft.EntityFrameworkCore;
using PruebaN5.DOMAIN.Entities;
using PruebaN5.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys
{
    public class PermisosRepository : Repository<Permiso>, IPermisosRepository
    {
        private readonly N5DBContext context;

        public PermisosRepository(N5DBContext context) : base(context)
        {
            this.context = context;
        }

        
    }
}
