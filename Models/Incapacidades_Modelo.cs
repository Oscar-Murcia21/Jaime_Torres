using System.ComponentModel.DataAnnotations;
namespace Jaime_Torres.Models
{
    public class Incapacidades_Modelo
    {
        [Required]
        public int Id_Incapacidad { get; set; }
        [Required]
        public int Id_Empleado { get; set; }
        [Required]
        public string Motivo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Dias { get; set; }
        [Required]
        public DateTime Fecha_Inicio { get; set; }
        [Required]
        public DateTime Fecha_Fin { get; set; }
        [Required]
        public DateTime Fecha_Creacion { get; set; }
        [Required]
        public DateTime Fecha_Modificacion { get; set; }
    }
}
