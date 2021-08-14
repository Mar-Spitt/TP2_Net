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
    public partial class frmComisiones : Form
    {
        public frmComisiones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            ComisionLogic co = new ComisionLogic();
            this.dgvComisiones.AutoGenerateColumns = false;
            try
            {
                this.dgvComisiones.DataSource = co.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error", "Error al recuperar lista de comisiones" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
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
            frmComisionesDesktop formComision = new frmComisionesDesktop(AplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                frmComisionesDesktop formComision = new frmComisionesDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                frmComisionesDesktop formComision = new frmComisionesDesktop(ID, AplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
        }

    }
}
