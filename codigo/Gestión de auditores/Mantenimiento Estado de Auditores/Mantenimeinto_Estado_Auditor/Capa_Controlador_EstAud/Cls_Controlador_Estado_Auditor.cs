using System;
using System.Data;
using Capa_Modelo_EstAud;

namespace Capa_Controlador_EstAud
{
    public class Cls_Controlador_Estado_Auditor
    {
        private Cls_Estado_Auditor_DAO modelo = new Cls_Estado_Auditor_DAO();

        public void Guardar(string nombre)
        {
            Validar(nombre);
            modelo.Insertar(nombre.Trim());
        }

        public DataTable Listar()
        {
            return modelo.Consultar();
        }

        public void Modificar(int id, string nombre)
        {
            if (id <= 0) throw new Exception("Seleccione un registro para modificar.");
            Validar(nombre);
            modelo.Actualizar(id, nombre.Trim());
        }

        public void Borrar(int id)
        {
            if (id <= 0) throw new Exception("Seleccione un registro para eliminar.");
            modelo.Eliminar(id);
        }

        private void Validar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre del estado es obligatorio.");
            if (nombre.Trim().Length > 45)
                throw new Exception("El nombre no puede exceder 45 caracteres.");
        }
    }
}