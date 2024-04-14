using System.ComponentModel.DataAnnotations;

namespace Jaime_Torres.Models
{
    public class Empleados_Modelo
    {
        [Required]
        public int Id_Empleado { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        [Required]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        public string Salario_Base { get; set; }
        [Required]
        public string Tipo_Contrato { get; set; }
        [Required]
        public string Nro_Cuenta { get; set; }
        [Required]
        public string Banco { get; set; }
        [Required]
        public DateTime Fecha_Creacion { get; set; }
        [Required]
        public DateTime Fecha_Modificacion { get; set; }
    }
}
