using PruebaN5.APPLICATION.DTOs;
using PruebaN5.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.APPLICATION.Interfaces
{
    public interface IPermisoAppService
    {
        Task<List<Permiso>> GetAll();
        Task<bool> Update(int Id, ModificarPermisoAppDto ModelDto);
        Task<Permiso?> GetAsync(int id);
    }
}
