using PruebaN5.DOMAIN.DTOs;
using PruebaN5.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.DOMAIN.Interfaces
{
    public interface IPermisosRepository : IRepository<Permiso>
    {
        Task<PermisoInfoDto?> GetWithInfo(int Id);
        Task<List<PermisoInfoDto>> GetAllWithInfo();
    }
}
