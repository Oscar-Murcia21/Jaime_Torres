using Jaime_Torres.Datos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jaime_Torres.Models.View_Models
{
    public class Empleado_Vacaciones_View
    {
        public Vacaciones_Modelo oVacaciones { get; set; }
        public List<SelectListItem> oListaEmpleados2 { get; set; }
    }
}
