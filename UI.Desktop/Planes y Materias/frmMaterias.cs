using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop.Planes_y_Materias
{
    public partial class frmMaterias : Form
    {
        public frmMaterias()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            MateriaLogic mat = new MateriaLogic();
            this.dgvMaterias.AutoGenerateColumns = false;
            try
            {
                this.dgvMaterias.DataSource = mat.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de materias" + Ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmMateriasDesktop formMateria = new frmMateriasDesktop(AplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                frmMateriasDesktop formMateria = new frmMateriasDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                frmMateriasDesktop formMateria = new frmMateriasDesktop(ID, AplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
        }
    }
}
