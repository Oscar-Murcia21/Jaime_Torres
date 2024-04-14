using Jaime_Torres.Datos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jaime_Torres.Models.View_Models
{
    public class Empleado_View
    {

        public Incapacidades_Modelo oIncapacidad { get; set; }
        public List<SelectListItem> oListaEmpleados { get; set; }



    }
}
