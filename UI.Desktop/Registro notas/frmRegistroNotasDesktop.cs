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
    public partial class frmRegistroNotasDesktop : AplicationForm
    {
        public frmRegistroNotasDesktop()
        {
            InitializeComponent();
        }
        public AlumnoInscripcion RegistroActual { get; set; }

        public frmRegistroNotasDesktop(int idP, int idC, int idIn, string mat, int anio , string com) : this()
        {
            RegistroActual = new AlumnoInscripcion();
            RegistroActual.ID = idIn;
            RegistroActual.IDAlumno = idP;
            RegistroActual.IDCurso = idC;
            RegistroActual.DescripcionMateria = mat;
            RegistroActual.AnioCalendario = anio;
            RegistroActual.DescripcionComision = com;
            RegistroActual.Condicion = " ";
            RegistroActual.Nota = 0;

            MapeardeDatos();
        }

        public void MapeardeDatos()
        {
            this.txtIdInscripcion.Text = this.RegistroActual.ID.ToString();
            this.txtCursoId.Text = this.RegistroActual.IDCurso.ToString();
            this.txtComision.Text = this.RegistroActual.DescripcionComision;
            this.txtMateria.Text = this.RegistroActual.DescripcionMateria;
            this.txtAnioCalendario.Text = this.RegistroActual.AnioCalendario.ToString();

            AlumnoLogic alu = new AlumnoLogic();
            Persona nuevoAlu = alu.GetOne(RegistroActual.IDAlumno);
            this.txtAlumnoLegajo.Text = nuevoAlu.Legajo.ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            RegistroActual.Condicion = this.txtCondicion.Text;
            RegistroActual.Nota = Convert.ToInt32(this.txtNota.Text);
            InscripcionLogic updateIns = new InscripcionLogic();
            updateIns.GuardarNota(RegistroActual);
            Notificar("Nota y condición registradas", "La nota y condición del alumno han sido registradas con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
