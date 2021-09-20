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
    public partial class frmRegistroNotas : Form
    {
        public frmRegistroNotas()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            InscripcionLogic ins = new InscripcionLogic();
            this.dgvRegistroNotas.AutoGenerateColumns = false;
            try
            {
                this.dgvRegistroNotas.DataSource = ins.GetAll();

                AlumnoLogic alu = new AlumnoLogic();
                this.id_alumno.DataSource = alu.GetAll();
                this.id_alumno.ValueMember = "ID";
                this.id_alumno.DisplayMember = "Nombre";
                // TODO: No muestra el Legajo de cada Alumno

                MateriaLogic mat = new MateriaLogic();
                this.id_materia.DataSource = mat.GetAll();
                this.id_materia.ValueMember = "ID";
                this.id_materia.DisplayMember = "Descripcion";

                ComisionLogic com = new ComisionLogic();
                this.id_comision.DataSource = com.GetAll();
                this.id_comision.ValueMember = "ID";
                this.id_comision.DisplayMember = "Descripcion";

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de inscripciones" + Ex, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegistroNotas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnCargarNota_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
