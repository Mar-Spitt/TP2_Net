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
    public partial class frmCursos : Form
    {
        public frmCursos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            CursoLogic ul = new CursoLogic();
            this.dgvCursos.AutoGenerateColumns = false;
            try
            {
                this.dgvCursos.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de curso " + Ex, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCursos_Load(object sender, EventArgs e)
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
            frmCursosDesktop formCurso = new frmCursosDesktop(AplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                frmCursosDesktop formCurso = new frmCursosDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                frmCursosDesktop formCurso = new frmCursosDesktop(ID, AplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
                this.Listar();
            }
        }
    }
}
