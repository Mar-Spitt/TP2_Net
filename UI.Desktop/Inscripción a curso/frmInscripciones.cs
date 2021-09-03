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

namespace UI.Desktop
{
    public partial class frmInscripciones : Form
    {
        public frmInscripciones()
        {
            InitializeComponent();
        }

        public int idUsuario;

        public frmInscripciones(int id)
        {
            InitializeComponent();
            idUsuario = id;
        }

        public void Listar()
        {
            CursoLogic ins = new CursoLogic();
            this.dgvInscripciones.AutoGenerateColumns = false;
            try
            {
                this.dgvInscripciones.DataSource = ins.GetAllWithCupos();


                MateriaLogic mat = new MateriaLogic();
                this.colMateria.DataSource = mat.GetAll();
                this.colMateria.ValueMember = "ID";
                this.colMateria.DisplayMember = "Descripcion";

                ComisionLogic com = new ComisionLogic();
                this.colDescripcionComisión.DataSource = com.GetAll();
                this.colDescripcionComisión.ValueMember = "ID";
                this.colDescripcionComisión.DisplayMember = "Descripcion";

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de curso con cupo > 0" + Ex, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInscripciones_Load(object sender, EventArgs e)
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

        private void btnElegir_Click(object sender, EventArgs e)
        {
            var fila = this.dgvInscripciones.CurrentRow;
            int idCurso = Convert.ToInt32(fila.Cells[0].Value);
            frmInscripcionesDesktop frmInscrip = new frmInscripcionesDesktop(idUsuario, idCurso);
            frmInscrip.ShowDialog();
        }
    }
}
