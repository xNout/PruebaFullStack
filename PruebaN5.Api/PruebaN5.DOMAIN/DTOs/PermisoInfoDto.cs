using PruebaN5.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaN5.DOMAIN.DTOs
{
    public record PermisoInfoDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = null!;
        public string ApellidoEmpleado { get; set; } = null!;
        public TipoPermiso TipoPermiso { get; set; } = null!;
        public DateTime FechaPermiso { get; set; }
    }
}
