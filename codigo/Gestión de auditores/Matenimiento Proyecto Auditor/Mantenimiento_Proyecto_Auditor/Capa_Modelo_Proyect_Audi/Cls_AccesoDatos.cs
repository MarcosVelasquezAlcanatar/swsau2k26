using System;
using System.Data;
using System.Data.Odbc;
using Seguridad = Capa_Modelo_Seguridad;

namespace Capa_Modelo_ProyAud
{
    public class Cls_AccesoDatos
    {
        private Seguridad.Cls_Conexion con = new Seguridad.Cls_Conexion();

        public void EjecutarComando(string sql, params object[] valores)
        {
            try
            {
                using (OdbcConnection conn = con.conexion())
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        foreach (object v in valores)
                            cmd.Parameters.AddWithValue("?", v ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception(TraducirError(ex.Message));
            }
        }

        public DataTable EjecutarConsulta(string sql)
        {
            try
            {
                using (OdbcConnection conn = con.conexion())
                {
                    conn.Open();
                    using (OdbcDataAdapter da = new OdbcDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al consultar datos: " + ex.Message);
            }
        }

        private string TraducirError(string m)
        {
            if (m.IndexOf("foreign key constraint fails", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Operación no permitida: el registro está relacionado con otra tabla o la llave foránea no existe.";
            if (m.IndexOf("Duplicate entry", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Ya existe un registro con ese valor.";
            if (m.IndexOf("Data too long", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Uno de los campos excede la longitud permitida.";
            if (m.IndexOf("cannot be null", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Hay campos obligatorios vacíos.";
            return "Error en la base de datos: " + m;
        }
    }
}