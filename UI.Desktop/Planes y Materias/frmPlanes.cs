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
    public partial class frmPlanes : Form
    {
        public frmPlanes()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            PlanLogic ul = new PlanLogic();
            this.dgvPlanes.AutoGenerateColumns = false;
            try
            {
                this.dgvPlanes.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error", "Error al recuperar lista de planes" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmPlanDesktop formPlan = new frmPlanDesktop(AplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                frmPlanDesktop formPlan = new frmPlanDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                frmPlanDesktop formPlan = new frmPlanDesktop(ID, AplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
        }
    }
}
