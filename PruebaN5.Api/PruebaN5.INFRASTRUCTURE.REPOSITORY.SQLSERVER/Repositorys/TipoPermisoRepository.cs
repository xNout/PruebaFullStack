using Microsoft.EntityFrameworkCore;
using PruebaN5.DOMAIN.DTOs;
using PruebaN5.DOMAIN.Entities;
using PruebaN5.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys
{
    public class TipoPermisoRepository : Repository<TipoPermiso>, ITipoPermisoRepository
    {
        public TipoPermisoRepository(N5DBContext context) : base(context)
        {
        }
    }
}
