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

        public void Listar()
        {
            CursoLogic ins = new CursoLogic();
            this.dgvInscripciones.AutoGenerateColumns = false;
            try
            {
                this.dgvInscripciones.DataSource = ins.GetAllWithCupos();
                ////this.colDescCurso.ValueMember = "ID";
                //this.colDescCurso.DisplayMember = "Descripcion";

                //MateriaLogic mat = new MateriaLogic();
                //this.dgvInscripciones.DataSource = mat.GetAll();
                ////this.colMateria.ValueMember = "ID";
                //this.colMateria.DisplayMember = 

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

        private void btnAceptar_Click(object sender, EventArgs e)
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

    }
}
