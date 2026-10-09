using System.Data;

namespace Capa_Modelo_EstAud
{
    public class Cls_Estado_Auditor_DAO
    {
        private Cls_AccesoDatos con = new Cls_AccesoDatos();

        public void Insertar(string nombre)
        {
            con.EjecutarComando(
                "INSERT INTO tbl_estado_auditor (Cmp_Nombre_Estado_Auditor) VALUES (?)",
                nombre);
        }

        public DataTable Consultar()
        {
            return con.EjecutarConsulta(
                "SELECT Pk_Id_Estado_Auditor, Cmp_Nombre_Estado_Auditor FROM tbl_estado_auditor");
        }

        public void Actualizar(int id, string nombre)
        {
            con.EjecutarComando(
                "UPDATE tbl_estado_auditor SET Cmp_Nombre_Estado_Auditor = ? WHERE Pk_Id_Estado_Auditor = ?",
                nombre, id);
        }

        public void Eliminar(int id)
        {
            con.EjecutarComando(
                "DELETE FROM tbl_estado_auditor WHERE Pk_Id_Estado_Auditor = ?",
                id);
        }
    }
}