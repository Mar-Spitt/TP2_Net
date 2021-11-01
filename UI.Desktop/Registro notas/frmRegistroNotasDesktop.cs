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

        public frmRegistroNotasDesktop(AlumnoInscripcion inscripcion) : this()
        {
            RegistroActual = inscripcion;

            this.txtIdInscripcion.Text = this.RegistroActual.ID.ToString();
            this.txtCursoDescripcion.Text = this.RegistroActual.DescripcionCurso;
            this.txtComisionDescripcion.Text = this.RegistroActual.DescripcionComision;
            this.txtMateriaDescripcion.Text = this.RegistroActual.DescripcionMateria;
            this.txtAnioCalendario.Text = this.RegistroActual.AnioCalendario.ToString();
            this.txtAlumnoNombreApellido.Text = this.RegistroActual.NombreApellidoAlu;
            this.txtNota.Text =this.RegistroActual.Nota.ToString();
            this.txtCondicion.Text = this.RegistroActual.Condicion.ToString();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int result;
            bool esNumerico = Int32.TryParse(this.txtNota.Text, out result);
            if (esNumerico)
            {
                if (result >= 0 && result <= 10)
                {
                    RegistroActual.Condicion = this.txtCondicion.Text;
                    RegistroActual.Nota = result;
                    InscripcionLogic updateIns = new InscripcionLogic();
                    updateIns.GuardarNota(RegistroActual);
                    Notificar("Nota y condición registradas", "La nota y condición del alumno han sido registradas con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    Notificar("Error Nota Inválida", "Ingrese una Nota comprendida entre 0 y 10", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Notificar("Error de tipo de dato", "Ingrese una Nota numérica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
