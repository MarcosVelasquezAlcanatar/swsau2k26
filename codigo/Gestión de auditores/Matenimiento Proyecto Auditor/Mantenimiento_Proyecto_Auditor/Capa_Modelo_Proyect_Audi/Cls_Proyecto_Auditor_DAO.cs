using System;
using System.Data;

namespace Capa_Modelo_ProyAud
{
    public class Cls_Proyecto_Auditor_DAO
    {
        private Cls_AccesoDatos con = new Cls_AccesoDatos();

        public void Insertar(int idProyecto, int idAuditor, int idPerfil, DateTime fecha)
        {
            con.EjecutarComando(
                "INSERT INTO tbl_proyecto_auditor " +
                "(Fk_Id_Proyecto, Fk_Id_Auditor, Fk_Id_Perfil_Auditor, Cmp_Fecha_Asignacion_Proyecto) " +
                "VALUES (?, ?, ?, ?)",
                idProyecto, idAuditor, idPerfil, fecha);
        }

        public DataTable Consultar()
        {
            return con.EjecutarConsulta(
                "SELECT Pk_Id_Proyecto_Auditor, Fk_Id_Proyecto, Fk_Id_Auditor, " +
                "Fk_Id_Perfil_Auditor, Cmp_Fecha_Asignacion_Proyecto FROM tbl_proyecto_auditor");
        }

        public void Actualizar(int id, int idProyecto, int idAuditor, int idPerfil, DateTime fecha)
        {
            con.EjecutarComando(
                "UPDATE tbl_proyecto_auditor SET Fk_Id_Proyecto = ?, Fk_Id_Auditor = ?, " +
                "Fk_Id_Perfil_Auditor = ?, Cmp_Fecha_Asignacion_Proyecto = ? " +
                "WHERE Pk_Id_Proyecto_Auditor = ?",
                idProyecto, idAuditor, idPerfil, fecha, id);
        }

        public void Eliminar(int id)
        {
            con.EjecutarComando(
                "DELETE FROM tbl_proyecto_auditor WHERE Pk_Id_Proyecto_Auditor = ?", id);
        }

        public DataTable ConsultarProyectos()
        {
            return con.EjecutarConsulta("SELECT Pk_Id_Proyecto, Cmp_Nombre_Proyecto FROM tbl_proyecto");
        }

        public DataTable ConsultarAuditores()
        {
            return con.EjecutarConsulta("SELECT Pk_Id_Auditor, Cmp_Nombre_Auditor FROM tbl_auditor");
        }

        public DataTable ConsultarPerfiles()
        {
            return con.EjecutarConsulta("SELECT Pk_Id_Perfil_Auditor, Cmp_Nombre_Perfil_Auditor FROM tbl_perfil_auditor");
        }
    }
}