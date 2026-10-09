using System;
using System.Windows.Forms;
using Capa_Controlador_ProyAud;

namespace Capa_Vista_ProyAud
{
    public partial class Mantenimiento_Proyecto_Auditor : Form
    {
        private Cls_Controlador_Proyecto_Auditor ctrl = new Cls_Controlador_Proyecto_Auditor();

        public Mantenimiento_Proyecto_Auditor()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Proyecto_Auditor_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
            Limpiar();
        }

        private void CargarCombos()
        {
            cmbProyecto.DataSource = ctrl.ListarProyectos();
            cmbProyecto.ValueMember = "Pk_Id_Proyecto";
            cmbProyecto.DisplayMember = "Cmp_Nombre_Proyecto";       // CAMBIAR

            cmbAuditor.DataSource = ctrl.ListarAuditores();
            cmbAuditor.ValueMember = "Pk_Id_Auditor";
            cmbAuditor.DisplayMember = "Cmp_Nombre_Auditor";         // CAMBIAR

            cmbPerfil.DataSource = ctrl.ListarPerfiles();
            cmbPerfil.ValueMember = "Pk_Id_Perfil_Auditor";
            cmbPerfil.DisplayMember = "Cmp_Nombre_Perfil_Auditor";   // CAMBIAR
        }

        private void CargarGrid()
        {
            dgvProyectoAuditor.DataSource = ctrl.Listar();
        }

        private void Limpiar()
        {
            txtId.Clear();
            cmbProyecto.SelectedIndex = -1;
            cmbAuditor.SelectedIndex = -1;
            cmbPerfil.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
        }

        private int IdActual()
        {
            int id;
            return int.TryParse(txtId.Text, out id) ? id : 0;
        }

        private int ValorCombo(ComboBox cmb)
        {
            return cmb.SelectedValue == null ? 0 : Convert.ToInt32(cmb.SelectedValue);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.Guardar(ValorCombo(cmbProyecto), ValorCombo(cmbAuditor),
                             ValorCombo(cmbPerfil), dtpFecha.Value.Date);
                MessageBox.Show("Registro guardado.");
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.Modificar(IdActual(), ValorCombo(cmbProyecto), ValorCombo(cmbAuditor),
                               ValorCombo(cmbPerfil), dtpFecha.Value.Date);
                MessageBox.Show("Registro actualizado.");
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Eliminar el registro?", "Confirmar",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                ctrl.Borrar(IdActual());
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvProyectoAuditor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvProyectoAuditor.Rows[e.RowIndex];

            txtId.Text = f.Cells[0].Value.ToString();
            cmbProyecto.SelectedValue = f.Cells[1].Value;
            cmbAuditor.SelectedValue = f.Cells[2].Value;
            cmbPerfil.SelectedValue = f.Cells[3].Value;
            if (f.Cells[4].Value != DBNull.Value)
                dtpFecha.Value = Convert.ToDateTime(f.Cells[4].Value);
        }
    }
}