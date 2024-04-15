using Jaime_Torres.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Jaime_Torres.Datos
{
    public class Vacaciones_Datos
    {

        public List<Vacaciones_Modelo> Listar_Vacaciones()
        {
            var oLista = new List<Vacaciones_Modelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Listar_Vacaciones", conexion);
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


                        oLista.Add(new Vacaciones_Modelo()
                        {
                            Id_Vacacion = Convert.ToInt32(dr["Id_Vacacion"]),
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
        public bool Guardar_Vacaciones(Vacaciones_Modelo ovacacion)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Crear_Vacacion", conexion);
                    cmd.Parameters.AddWithValue("Id_Empleado", ovacacion.Id_Empleado);
                    cmd.Parameters.AddWithValue("Motivo", ovacacion.Motivo);
                    cmd.Parameters.AddWithValue("Descripcion", ovacacion.Descripcion);
                    cmd.Parameters.AddWithValue("Dias", ovacacion.Dias);
                    cmd.Parameters.AddWithValue("Fecha_Inicio", ovacacion.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("Fecha_Fin", ovacacion.Fecha_Fin);
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

    }
}
