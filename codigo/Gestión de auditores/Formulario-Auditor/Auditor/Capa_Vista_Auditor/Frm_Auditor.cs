using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Auditor;

namespace Capa_Vista_Auditor
{
    public partial class Frm_Auditor : Form
    {
        Cls_auditor_controlador controlador = new Cls_auditor_controlador();
        public Frm_Auditor()
        {
            InitializeComponent();
        }

        private void Frm_Auditor_Load(object sender, EventArgs e)
        {
            try
            {
                string sBaseDatos = controlador.ProbarConexion();
                MessageBox.Show("Conectado a la base de datos: " + sBaseDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
