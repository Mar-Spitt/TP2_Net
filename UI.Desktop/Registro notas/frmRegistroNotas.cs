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
                // IDALUMNO, IDCURSO, CONDICION, NOTA

                AlumnoLogic alu = new AlumnoLogic();
                this.id_alumno.DataSource = alu.GetAll();
                this.id_alumno.ValueMember = "ID";
                this.id_alumno.DisplayMember = "Nombre";
                // TODO: Cerrar ABM registro de Notas

                CursoLogic cur = new CursoLogic();
                this.id_curso.DataSource = cur.GetAll();
                this.id_curso.ValueMember = "ID";
                this.id_curso.DisplayMember = "Descripcion"; 

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
            int idCurso = Convert.ToInt32(fila.Cells[1].Value);
            int idInscripcion = Convert.ToInt32(fila.Cells[0].Value);
            int idPersona = Convert.ToInt32(fila.Cells[1].Value);
            string materia = fila.Cells[3].Value.ToString();
            int anio = Convert.ToInt32(fila.Cells[4].Value);
            string comision = fila.Cells[5].Value.ToString();
            frmRegistroNotasDesktop frmReg = new frmRegistroNotasDesktop(idPersona, idCurso, idInscripcion, materia, anio, comision);
            frmReg.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
