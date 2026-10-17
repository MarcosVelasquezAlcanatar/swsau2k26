using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;   

namespace Capa_Modelo_Auditor
{
    public class Cls_auditorDAO
    {
        // Conexion desde modelo seguridad
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_LISTADO = @"
        SELECT
            a.Pk_Id_Auditor,
            a.Cmp_Carnet_Auditor,
            a.Cmp_Nombre_Auditor,
            a.Cmp_Telefono_Auditor,
            a.Cmp_Email_Auditor,
            a.Fk_Id_Estado_Auditor
        FROM tbl_auditor a
        ORDER BY a.Pk_Id_Auditor ASC";

        public DataTable ObtenerAuditores()
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_LISTADO, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public string ProbarConexion()
        {
            using (OdbcConnection conn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand("SELECT DATABASE()", conn))
            {
                return cmd.ExecuteScalar().ToString();
            }
        }
    }
}
