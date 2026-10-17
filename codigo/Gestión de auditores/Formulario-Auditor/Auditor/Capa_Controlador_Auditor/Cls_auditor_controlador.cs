
using System;
using System.Data;
using Capa_Modelo_Auditor;

namespace Capa_Controlador_Auditor
{
    public class Cls_auditor_controlador
    {
        private Cls_auditorDAO dao = new Cls_auditorDAO();

        public DataTable ObtenerAuditores()
        {
            return dao.ObtenerAuditores();
        }

        // (D) PRUEBA DE CONEXIÓN
        public string ProbarConexion()
        {
            return dao.ProbarConexion();
        }
    }
}