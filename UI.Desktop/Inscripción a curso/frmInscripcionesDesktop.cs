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

        public frmInscripcionesDesktop(int idP, int idC) : this()
        {
            InscripcionActual = new AlumnoInscripcion();
            InscripcionActual.IDAlumno = idP;
            InscripcionActual.IDCurso = idC;
            InscripcionActual.Condicion = " ";

            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtAlumno.Text = this.InscripcionActual.IDAlumno.ToString();
            this.txtCurso.Text = this.InscripcionActual.IDCurso.ToString();
            
            AlumnoLogic alu = new AlumnoLogic();
            Persona nuevoAlu = alu.GetOne(InscripcionActual.IDAlumno);
            this.txtAlumno.Text = nuevoAlu.ID.ToString();
            this.txtAlumnoNombre.Text = nuevoAlu.Nombre +" " + nuevoAlu.Apellido;

            CursoLogic cur = new CursoLogic();
            Curso nuevoCur = cur.GetOne(InscripcionActual.IDCurso);
            this.txtCursoNombre.Text = nuevoCur.Descripcion;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            InscripcionLogic nuevaIns = new InscripcionLogic();
            nuevaIns.Save(InscripcionActual);
            Notificar("Inscripción registrada", "Su inscripción ha sido registrada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
