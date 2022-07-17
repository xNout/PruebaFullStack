using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaN5.APPLICATION.DTOs;
using PruebaN5.APPLICATION.Interfaces;
using PruebaN5.DOMAIN.Entities;
using PruebaN5.DOMAIN.Interfaces;

namespace PruebaN5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IPermisoAppService permisoAppService;

        public PermisosController(IPermisoAppService permisoAppService)
        {
            this.permisoAppService = permisoAppService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ModificarPermisoAppDto ModelDto)
        {
            bool Actualizar = await permisoAppService.Update(id, ModelDto);
            if (!Actualizar)
                return NotFound();

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Permiso? permiso = await permisoAppService.GetAsync(id);
            if (permiso is null)
                return NotFound();

            return Ok(permiso);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await permisoAppService.GetAll());
        }
    }
}
