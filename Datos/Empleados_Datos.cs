using Jaime_Torres.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Jaime_Torres.Datos
{
    public class Empleados_Datos
    {
        private DateTime v;

        public List<Empleados_Modelo> Listar_Empleado()
        {
            var oLista = new List<Empleados_Modelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Listar_Empleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string v = dr["Fecha_Ingreso"].ToString();
                        DateTime dtnew = DateTime.Parse(v);
                        v = dr["Fecha_Creacion"].ToString();
                        DateTime dtnew1 = DateTime.Parse(v);
                        v = dr["Fecha_Modificacion"].ToString();
                        DateTime dtnew2 = DateTime.Parse(v);


                        oLista.Add(new Empleados_Modelo()
                        {
                            Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo_Electronico = dr["Correo_Electronico"].ToString(),
                            Cargo = dr["Cargo"].ToString(),
                            Departamento = dr["Departamento"].ToString(),
                            Fecha_Ingreso = dtnew,
                            Salario_Base = dr["Salario_Base"].ToString(),
                            Tipo_Contrato = dr["Tipo_Contrato"].ToString(),
                            Nro_Cuenta = dr["Nro_Cuenta"].ToString(),
                            Banco = dr["Banco"].ToString(),
                            Fecha_Creacion = dtnew1,
                            Fecha_Modificacion = dtnew2
                        });
                    }

                }

            }
            return oLista;
        }

        public Empleados_Modelo Consultar_Empleado(int Id)
        {
            var oContacto = new Empleados_Modelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Consultar_Empleado", conexion);
                cmd.Parameters.AddWithValue("Id_Empleado", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                  
                    while (dr.Read())
                    {
                        string v = dr["Fecha_Ingreso"].ToString();
                        DateTime dtnew = DateTime.Parse(v);
                        v = dr["Fecha_Creacion"].ToString();
                        DateTime dtnew1 = DateTime.Parse(v);
                        v = dr["Fecha_Modificacion"].ToString();
                        DateTime dtnew2 = DateTime.Parse(v);
                        oContacto.Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]);
                        oContacto.Nombres = dr["Nombres"].ToString();
                        oContacto.Apellidos = dr["Apellidos"].ToString();
                        oContacto.Direccion = dr["Direccion"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo_Electronico = dr["Correo_Electronico"].ToString();
                        oContacto.Cargo = dr["Cargo"].ToString();
                        oContacto.Departamento = dr["Departamento"].ToString();
                        oContacto.Fecha_Ingreso = dtnew;
                        oContacto.Salario_Base = dr["Salario_Base"].ToString();
                        oContacto.Tipo_Contrato = dr["Tipo_Contrato"].ToString();
                        oContacto.Nro_Cuenta = dr["Nro_Cuenta"].ToString();
                        oContacto.Banco = dr["Banco"].ToString();
                        oContacto.Fecha_Creacion = dtnew1;
                        oContacto.Fecha_Modificacion = dtnew2;
                    }

                }

            }
            return oContacto;
        }
        public bool Guardar_Empleado(Empleados_Modelo ocontacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Crear_Empleado", conexion);
                    cmd.Parameters.AddWithValue("Nombres", ocontacto.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", ocontacto.Apellidos);
                    cmd.Parameters.AddWithValue("Direccion", ocontacto.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo_Electronico", ocontacto.Correo_Electronico);
                    cmd.Parameters.AddWithValue("Cargo", ocontacto.Cargo);
                    cmd.Parameters.AddWithValue("Departamento", ocontacto.Departamento);
                    cmd.Parameters.AddWithValue("Fecha_ingreso", ocontacto.Fecha_Ingreso);
                    cmd.Parameters.AddWithValue("Salario_Base", ocontacto.Salario_Base);
                    cmd.Parameters.AddWithValue("Tipo_Contrato", ocontacto.Tipo_Contrato);
                    cmd.Parameters.AddWithValue("Nro_Cuenta", ocontacto.Nro_Cuenta);
                    cmd.Parameters.AddWithValue("Banco", ocontacto.Banco);
                    cmd.Parameters.AddWithValue("Fecha_Creacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("Fecha_Modificacion", DateTime.Now);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            return rpta;
        }
        public bool Editar_Empleado(Empleados_Modelo ocontacto)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Editar_Empleado", conexion);
                    cmd.Parameters.AddWithValue("Id_Empleado", ocontacto.Id_Empleado);
                    cmd.Parameters.AddWithValue("Nombres", ocontacto.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", ocontacto.Apellidos);
                    cmd.Parameters.AddWithValue("Direccion", ocontacto.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo_Electronico", ocontacto.Correo_Electronico);
                    cmd.Parameters.AddWithValue("Cargo", ocontacto.Cargo);
                    cmd.Parameters.AddWithValue("Departamento", ocontacto.Departamento);
                    cmd.Parameters.AddWithValue("Fecha_ingreso", ocontacto.Fecha_Ingreso);
                    cmd.Parameters.AddWithValue("Salario_Base", ocontacto.Salario_Base);
                    cmd.Parameters.AddWithValue("Tipo_Contrato", ocontacto.Tipo_Contrato);
                    cmd.Parameters.AddWithValue("Nro_Cuenta", ocontacto.Nro_Cuenta);
                    cmd.Parameters.AddWithValue("Banco", ocontacto.Banco);
                    cmd.Parameters.AddWithValue("Fecha_Creacion", ocontacto.Fecha_Creacion);
                    cmd.Parameters.AddWithValue("Fecha_Modificacion", DateTime.Now);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar_Empleado(int Id_Empleado)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar_Empleado", conexion);
                    cmd.Parameters.AddWithValue("Id_Empleado", Id_Empleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            return rpta;
        }

    }
}
