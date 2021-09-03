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
    public partial class frmInscripcionesDesktop : AplicationForm
    {
        public frmInscripcionesDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcion InscripcionActual { get; set; }

        public frmInscripcionesDesktop(int idA, int idC)
        {
            //TODO: Seguir aca
            InscripcionActual.IDAlumno = idA;
            InscripcionActual.IDCurso = idC;
            InscripcionActual.Condicion = " ";
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtAlumno.Text = this.InscripcionActual.IDAlumno.ToString();
            this.txtCurso.Text = this.InscripcionActual.IDCurso.ToString();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
