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
    public class PermisosRepository : Repository<Permiso>, IPermisosRepository
    {
        

        public PermisosRepository(N5DBContext context) : base(context)
        {
        }
        public async Task<PermisoInfoDto?> GetWithInfo(int Id)
        {
            return await (from permiso in context.Permisos.AsQueryable()
                          join tipopermiso in context.TipoPermisos.AsQueryable()
                          on permiso.TipoPermiso equals tipopermiso.Id
                          where permiso.Id == Id
                          select new PermisoInfoDto
                          {
                              Id = permiso.Id,
                              TipoPermiso = tipopermiso,
                              NombreEmpleado = permiso.NombreEmpleado,
                              ApellidoEmpleado = permiso.ApellidoEmpleado,
                              FechaPermiso = permiso.FechaPermiso
                          }).FirstOrDefaultAsync();
        }
        public async Task<List<PermisoInfoDto>> GetAllWithInfo()
        {
            return await (from permiso in context.Permisos.AsQueryable()
                    join tipopermiso in context.TipoPermisos.AsQueryable()
                    on permiso.TipoPermiso equals tipopermiso.Id
                    select new PermisoInfoDto
                    {
                        Id = permiso.Id,
                        TipoPermiso = tipopermiso,
                        NombreEmpleado = permiso.NombreEmpleado,
                        ApellidoEmpleado = permiso.ApellidoEmpleado,
                        FechaPermiso = permiso.FechaPermiso
                    }).ToListAsync();
        }
    }
}
