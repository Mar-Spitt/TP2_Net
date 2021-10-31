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

        public AlumnoInscripcion AlumnoInsc { get; set; }
        public InscripcionLogic Logic { get; set; }

        public void Listar()
        {
            Logic = new InscripcionLogic();
            this.dgvRegistroNotas.AutoGenerateColumns = false;
            try
            {
                this.dgvRegistroNotas.DataSource = Logic.GetAll();
                // IDALUMNO, IDCURSO, CONDICION, NOTA

                //AlumnoLogic alu = new AlumnoLogic();
                //this.id_alumno.DataSource = alu.GetAll();
                //this.id_alumno.ValueMember = "ID";
                //this.id_alumno.DisplayMember = "Nombre";

                //CursoLogic cur = new CursoLogic();
                //this.id_curso.DataSource = cur.GetAll();
                //this.id_curso.ValueMember = "ID";
                //this.id_curso.DisplayMember = "Descripcion"; 

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
            var fila = this.dgvRegistroNotas.CurrentRow;
            AlumnoInsc = Logic.GetOne(Convert.ToInt32(this.dgvRegistroNotas.CurrentRow.Cells[0].Value));

            frmRegistroNotasDesktop frmReg = new frmRegistroNotasDesktop(AlumnoInsc);
            frmReg.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
