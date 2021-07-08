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

namespace UI.Desktop.Alumnos
{
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            AlumnoLogic alu = new AlumnoLogic();
            this.dgvAlumnos.AutoGenerateColumns = false;
            try
            {
                this.dgvAlumnos.DataSource = alu.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error", "Error al recuperar lista de alumnos" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmAlumnosDesktop formAlumnos = new frmAlumnosDesktop(AplicationForm.ModoForm.Alta);
            formAlumnos.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                frmAlumnosDesktop formAlumno = new frmAlumnosDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formAlumno.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                frmAlumnosDesktop formAlumno = new frmAlumnosDesktop(ID, AplicationForm.ModoForm.Baja);
                formAlumno.ShowDialog();
                this.Listar();
            }
        }
    }
}
