using System;
using System.Linq;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class frmProfesores : Form
    {
        public frmProfesores()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            ProfesorLogic profe = new ProfesorLogic();
            this.dgvProfesores.AutoGenerateColumns = false;
            try
            {
                this.dgvProfesores.DataSource = profe.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error", "Error al recuperar lista de profesores" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
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
            frmProfesoresDesktop formProfesores = new frmProfesoresDesktop(AplicationForm.ModoForm.Alta);
            formProfesores.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvProfesores.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvProfesores.SelectedRows[0].DataBoundItem).ID;
                frmProfesoresDesktop formProfesor = new frmProfesoresDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formProfesor.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvProfesores.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvProfesores.SelectedRows[0].DataBoundItem).ID;
                frmProfesoresDesktop formProfesor = new frmProfesoresDesktop(ID, AplicationForm.ModoForm.Baja);
                formProfesor.ShowDialog();
                this.Listar();
            }
        }
    }
}
