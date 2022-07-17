using PruebaN5.APPLICATION.DTOs;
using PruebaN5.APPLICATION.Interfaces;
using PruebaN5.DOMAIN.Entities;
using PruebaN5.DOMAIN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.APPLICATION.AppService
{
    public class PermisoAppService : IPermisoAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public PermisoAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Update(int Id, ModificarPermisoAppDto ModelDto)
        {
            try
            {
                Permiso? permiso = await unitOfWork.permisosRepository.GetAsync(Id);
                if (permiso is null)
                    return false;

                await unitOfWork.BeginTransaction();

                permiso.NombreEmpleado = ModelDto.NombreEmpleado;
                permiso.ApellidoEmpleado = ModelDto.ApellidoEmpleado;
                permiso.TipoPermiso = ModelDto.TipoPermiso;
                permiso.FechaPermiso = DateTime.Now;

                unitOfWork.permisosRepository.Update(permiso);
                await unitOfWork.SaveChanges();
                await unitOfWork.CommitTransaction();
                return true;
            }
            catch
            {
                await unitOfWork.RollbackTransaction();
                return false;
            }
        }
        public async Task<List<Permiso>> GetAll() => await unitOfWork.permisosRepository.GetAll();
        public async Task<Permiso?> GetAsync(int id) => await unitOfWork.permisosRepository.GetAsync(id);
    }
}
