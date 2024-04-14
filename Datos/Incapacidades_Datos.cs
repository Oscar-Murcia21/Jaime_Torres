using Jaime_Torres.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Jaime_Torres.Datos
{
    public class Incapacidades_Datos
    {
        public List<Incapacidades_Modelo> Listar_Incapacidad()
        {
            var oLista = new List<Incapacidades_Modelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Listar_Incapacidades", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string v = dr["Fecha_Inicio"].ToString();
                        DateTime dtnew = DateTime.Parse(v);
                        v = dr["Fecha_Fin"].ToString();
                        DateTime dtnew1 = DateTime.Parse(v);
                        v = dr["Fecha_Creacion"].ToString();
                        DateTime dtnew2 = DateTime.Parse(v);
                        v = dr["Fecha_Modificacion"].ToString();
                        DateTime dtnew3 = DateTime.Parse(v);


                        oLista.Add(new Incapacidades_Modelo()
                        {
                            Id_Incapacidad = Convert.ToInt32(dr["Id_Incapacidad"]),
                            Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]),
                            Motivo = dr["Motivo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Dias = dr["Dias"].ToString(),
                            Fecha_Inicio = dtnew,
                            Fecha_Fin = dtnew1,
                            Fecha_Creacion = dtnew2,
                            Fecha_Modificacion = dtnew3
                        });
                    }

                }

            }
            return oLista;
        }

        public bool Guardar_Incapacidad(Incapacidades_Modelo oincapacidad)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Crear_Incapacidad", conexion);
                    cmd.Parameters.AddWithValue("Id_Empleado", oincapacidad.Id_Empleado);
                    cmd.Parameters.AddWithValue("Motivo", oincapacidad.Motivo);
                    cmd.Parameters.AddWithValue("Descripcion", oincapacidad.Descripcion);
                    cmd.Parameters.AddWithValue("Dias", oincapacidad.Dias);
                    cmd.Parameters.AddWithValue("Fecha_Inicio", oincapacidad.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("Fecha_Fin", oincapacidad.Fecha_Fin);
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

        public Incapacidades_Modelo Consultar_Incapacidad(int Id)
        {
            var oIncapacidad = new Incapacidades_Modelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Consultar_Incapacidad", conexion);
                cmd.Parameters.AddWithValue("Id_Incapacidad", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        string v = dr["Fecha_Inicio"].ToString();
                        DateTime dtnew = DateTime.Parse(v);
                        v = dr["Fecha_Fin"].ToString();
                        DateTime dtnew1 = DateTime.Parse(v);
                        v = dr["Fecha_Creacion"].ToString();
                        DateTime dtnew2 = DateTime.Parse(v);
                        v = dr["Fecha_Modificacion"].ToString();
                        DateTime dtnew3 = DateTime.Parse(v);
                        oIncapacidad.Id_Incapacidad = Convert.ToInt32(dr["Id_Incapacidad"]);
                        oIncapacidad.Id_Empleado = Convert.ToInt32(dr["Id_Empleado"]);
                        oIncapacidad.Motivo = dr["Motivo"].ToString();
                        oIncapacidad.Descripcion = dr["Descripcion"].ToString();
                        oIncapacidad.Dias = dr["Dias"].ToString();
                        oIncapacidad.Fecha_Inicio = dtnew;
                        oIncapacidad.Fecha_Fin = dtnew1;
                        oIncapacidad.Fecha_Creacion = dtnew2;
                        oIncapacidad.Fecha_Modificacion = dtnew3;
                    }

                }

            }
            return oIncapacidad;
        }

        public bool Editar_Incapacidad(Incapacidades_Modelo oincapacidad)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Editar_Incapacidad", conexion);
                    cmd.Parameters.AddWithValue("Id_Incapacidad", oincapacidad.Id_Incapacidad);
                    cmd.Parameters.AddWithValue("Id_Empleado", oincapacidad.Id_Empleado);
                    cmd.Parameters.AddWithValue("Motivo", oincapacidad.Motivo);
                    cmd.Parameters.AddWithValue("Descripcion", oincapacidad.Descripcion);
                    cmd.Parameters.AddWithValue("Dias", oincapacidad.Dias);
                    cmd.Parameters.AddWithValue("Fecha_Inicio", oincapacidad.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("Fecha_Fin", oincapacidad.Fecha_Fin);
                    cmd.Parameters.AddWithValue("Fecha_Creacion", oincapacidad.Fecha_Creacion);
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

        public bool Eliminar_Incapacidad(int Id_Incapacidad)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar_Incapacidad", conexion);
                    cmd.Parameters.AddWithValue("Id_Incapacidad", Id_Incapacidad);
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
