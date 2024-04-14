using Microsoft.AspNetCore.Mvc;
using Jaime_Torres.Datos;
using Jaime_Torres.Models;
using Jaime_Torres.Models.View_Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jaime_Torres.Controllers
{
    public class Principal_Controlador : Controller
    {
        Empleados_Datos contactoDatos = new Empleados_Datos();
        Incapacidades_Datos incapacidadDatos = new Incapacidades_Datos();
    
        public IActionResult Listar_Empleados()
        {
            var oLista = contactoDatos.Listar_Empleado();
            return View(oLista);
        }
        public IActionResult Guardar_Empleados(Empleados_Modelo oContacto)
        {
            var respuesta = contactoDatos.Guardar_Empleado(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar_Empleados");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editar_Empleados(int Id)
        {
            var oContacto = contactoDatos.Consultar_Empleado(Id);
            return View(oContacto);
        }
        //Vista de actualizar usuarios
        public IActionResult Modificar_Empleados(Empleados_Modelo oContacto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Editar_Empleados");
            }

            var respuesta = contactoDatos.Editar_Empleado(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar_Empleados");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar_Empleados(int Id)
        {
            var oContacto = contactoDatos.Consultar_Empleado(Id);
            return View(oContacto);
        }

        public IActionResult Borrar_Empleado(Empleados_Modelo oContacto)
        {
            var respuesta = contactoDatos.Eliminar_Empleado(oContacto.Id_Empleado);
            if (respuesta)
            {
                return RedirectToAction("Listar_Empleados");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Listar_Incapacidades()
        {
            var oLista = incapacidadDatos.Listar_Incapacidad();
            return View(oLista);
        }

        public IActionResult Guardar_Incapacidades(Incapacidades_Modelo oIncapacidad)
        {
            var respuesta = incapacidadDatos.Guardar_Incapacidad(oIncapacidad);
            if (respuesta)
            {
                return RedirectToAction("Listar_Incapacidades");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Empleados_Detalle() 
        {

            var oLista = contactoDatos.Listar_Empleado();
            //return View(oLista);


            Empleado_View oEmpleado_View = new Empleado_View() {
                oIncapacidad = new Incapacidades_Modelo(),
                oListaEmpleados = oLista.Select(cargo => new SelectListItem(){
                    Text = cargo.Nombres,
                    Value = cargo.Id_Empleado.ToString()
                }).ToList()
            };
            return View(oEmpleado_View);
        }

        public IActionResult Editar_Incapacidades(int Id)
        {
            var oIncapacidad2 = incapacidadDatos.Consultar_Incapacidad(Id);

            var oLista = contactoDatos.Listar_Empleado();
            //return View(oLista);


            Empleado_View oEmpleado_View = new Empleado_View()
            {
                oIncapacidad = oIncapacidad2,
                oListaEmpleados = oLista.Select(cargo => new SelectListItem()
                {
                    Text = cargo.Nombres,
                    Value = cargo.Id_Empleado.ToString()
                }).ToList()
            };
            return View(oEmpleado_View);


            //return View(oIncapacidad);
        }

        public IActionResult Modificar_Incapacidades(Incapacidades_Modelo oIncapacidad)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Editar_Incapacidades");
            }

            var respuesta = incapacidadDatos.Editar_Incapacidad(oIncapacidad);
            if (respuesta)
            {
                return RedirectToAction("Listar_Incapacidades");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar_Incapacidades(int Id)
        {
            var oContacto = incapacidadDatos.Consultar_Incapacidad(Id);
            return View(oContacto);
        }

        public IActionResult Borrar_Incapacidad(Incapacidades_Modelo oIncapacidad)
        {
            var respuesta = incapacidadDatos.Eliminar_Incapacidad(oIncapacidad.Id_Incapacidad);
            if (respuesta)
            {
                return RedirectToAction("Listar_Incapacidades");
            }
            else
            {
                return View();
            }
        }


    }
}
