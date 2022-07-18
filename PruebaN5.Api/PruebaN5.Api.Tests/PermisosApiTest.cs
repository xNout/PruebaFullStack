using Microsoft.AspNetCore.Mvc;
using PruebaN5.Api.Controllers;
using PruebaN5.APPLICATION.AppService;
using PruebaN5.APPLICATION.DTOs;
using PruebaN5.DOMAIN.DTOs;
using PruebaN5.DOMAIN.Entities;
using PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER;
using PruebaN5.INFRASTRUCTURE.REPOSITORY.SQLSERVER.Repositorys;
using System.Net;
using System.Web.Http.Results;

namespace PruebaN5.Api.Tests
{
    public class PermisosApiTest
    {
        private readonly PermisosController controlador;
        public PermisosApiTest()
        {
            string ConnectionString = "Data Source=45.70.14.114,444;Initial Catalog=MARDANNY_SYS;User ID=mardanny;Password=m4rd4nny123GG.;Persist Security Info=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Connection Timeout=180;";
            var context = new N5DBContext(ConnectionString);
            var unitOfWork = new UnitOfWork(context);
            var permisosService = new PermisoAppService(unitOfWork);
            this.controlador = new PermisosController(permisosService);
        }

        [Fact]
        public async Task SolicitarPermisoTest()
        {
            List<Permiso> items = GetItemsTest();

            var result = await controlador.Get(4) as OkObjectResult;

            Assert.NotNull(result);

            Assert.IsType<PermisoInfoDto>(result?.Value);
            PermisoInfoDto? permiso = (PermisoInfoDto?)result?.Value;
            Assert.Equal(items.First(x => x.Id == 4).NombreEmpleado, permiso?.NombreEmpleado);
        }
        [Fact]
        public async Task SolicitarPermisoNoExistenteTest()
        {
            var result = await controlador.Get(1);

            Assert.NotNull(result);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }
        [Fact]
        public async Task ObtenerPermisosTest()
        {
            var result = await controlador.GetAll() as OkObjectResult;

            Assert.NotNull(result);

            Assert.IsType<List<PermisoInfoDto>>(result?.Value);

            List<PermisoInfoDto>? permisos = (List<PermisoInfoDto>?)result?.Value;
            Assert.Equal(6, permisos?.Count);
        }
        [Fact]
        public async Task ModificarPermisoTest()
        {
            ModificarPermisoAppDto ModelDto = new()
            {
                NombreEmpleado = "ADRIAN",
                ApellidoEmpleado = "VERA",
                TipoPermiso = 1
            };

            var result = await controlador.Update(4, ModelDto);

            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task ModificarPermisoNoExistenteTest()
        {
            ModificarPermisoAppDto ModelDto = new()
            {
                NombreEmpleado = "ADRIAN",
                ApellidoEmpleado = "VERA",
                TipoPermiso = 1
            };

            var result = await controlador.Update(1, ModelDto);

            Assert.NotNull(result);
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(result);
        }
        List<Permiso> GetItemsTest()
        {
            var result = new List<Permiso>()
            {
                new Permiso{ Id = 4, NombreEmpleado = "ADRIAN", ApellidoEmpleado = "VERA", TipoPermiso = 1, FechaPermiso = DateTime.Now },
                new Permiso{ Id = 5, NombreEmpleado = "ERNESTO", ApellidoEmpleado = "CABALLERO", TipoPermiso = 3, FechaPermiso = DateTime.Now },
                new Permiso{ Id = 6, NombreEmpleado = "LUIS", ApellidoEmpleado = "DEL VALLE", TipoPermiso = 3, FechaPermiso = DateTime.Now },
                new Permiso{ Id = 7, NombreEmpleado = "TULIO", ApellidoEmpleado = "VILLARES", TipoPermiso = 3, FechaPermiso = DateTime.Now },
                new Permiso{ Id = 8, NombreEmpleado = "IVAN", ApellidoEmpleado = "JIMENEZ", TipoPermiso = 2, FechaPermiso = DateTime.Now },
                new Permiso{ Id = 9, NombreEmpleado = "EDGAR", ApellidoEmpleado = "CLAVIJO", TipoPermiso = 2, FechaPermiso = DateTime.Now },
            };


            return result;
        }
    }
}