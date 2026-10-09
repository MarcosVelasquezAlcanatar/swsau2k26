using System;
using System.Windows.Forms;
using Capa_Controlador_EstAud;

namespace Capa_Vista_EstAud
{
    public partial class Mantenimiento_Estado_Auditor : Form
    {
        private Cls_Controlador_Estado_Auditor ctrl = new Cls_Controlador_Estado_Auditor();

        public Mantenimiento_Estado_Auditor()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Estado_Auditor_Load(object sender, EventArgs e)
        {
            CargarGrid();
            Limpiar();
        }

        private void CargarGrid()
        {
            dgvEstados.DataSource = ctrl.Listar();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private int IdActual()
        {
            int id;
            return int.TryParse(txtId.Text, out id) ? id : 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e) { Limpiar(); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.Guardar(txtNombre.Text);
                MessageBox.Show("Registro guardado.");
                CargarGrid(); Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.Modificar(IdActual(), txtNombre.Text);
                MessageBox.Show("Registro actualizado.");
                CargarGrid(); Limpiar();
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
                CargarGrid(); Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // Al hacer clic en una fila, pasa los datos a los textbox
        private void dgvEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvEstados.Rows[e.RowIndex];
            txtId.Text = fila.Cells[0].Value.ToString();
            txtNombre.Text = fila.Cells[1].Value.ToString();
        }
    }
}