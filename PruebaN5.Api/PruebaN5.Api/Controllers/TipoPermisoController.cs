using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PruebaN5.DOMAIN.Interfaces;

namespace PruebaN5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    // Sirve de ayuda para el formulario de modificacion
    public class TipoPermisoController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public TipoPermisoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await unitOfWork.tipoPermisoRepository.GetAll());
        }
    }
}
