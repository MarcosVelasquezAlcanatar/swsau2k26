using System;
using System.Data;
using Capa_Modelo_ProyAud;

namespace Capa_Controlador_ProyAud
{
    public class Cls_Controlador_Proyecto_Auditor
    {
        private Cls_Proyecto_Auditor_DAO modelo = new Cls_Proyecto_Auditor_DAO();

        public void Guardar(int idProyecto, int idAuditor, int idPerfil, DateTime fecha)
        {
            Validar(idProyecto, idAuditor, idPerfil);
            modelo.Insertar(idProyecto, idAuditor, idPerfil, fecha);
        }

        public DataTable Listar() { return modelo.Consultar(); }

        public void Modificar(int id, int idProyecto, int idAuditor, int idPerfil, DateTime fecha)
        {
            if (id <= 0) throw new Exception("Seleccione un registro para modificar.");
            Validar(idProyecto, idAuditor, idPerfil);
            modelo.Actualizar(id, idProyecto, idAuditor, idPerfil, fecha);
        }

        public void Borrar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un registro para eliminar.");
            modelo.Eliminar(id);
        }

        public DataTable ListarProyectos() { return modelo.ConsultarProyectos(); }
        public DataTable ListarAuditores() { return modelo.ConsultarAuditores(); }
        public DataTable ListarPerfiles() { return modelo.ConsultarPerfiles(); }

        private void Validar(int idProyecto, int idAuditor, int idPerfil)
        {
            if (idProyecto <= 0) throw new Exception("Seleccione un proyecto.");
            if (idAuditor <= 0) throw new Exception("Seleccione un auditor.");
            if (idPerfil <= 0) throw new Exception("Seleccione un perfil de auditor.");
        }
    }
}