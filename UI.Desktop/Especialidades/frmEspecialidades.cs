using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            EspecialidadLogic ul = new EspecialidadLogic();
            this.dgvEspecialidades.AutoGenerateColumns = false;
            try
            {
                this.dgvEspecialidades.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error", "Error al recuperar lista de especialidades" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            frmEspecialidDesktop formEspecialidad = new frmEspecialidDesktop(AplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                frmEspecialidDesktop formEspecialidad = new frmEspecialidDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                frmEspecialidDesktop formEspecialidad = new frmEspecialidDesktop(ID, AplicationForm.ModoForm.Baja);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
        }
    }
}
