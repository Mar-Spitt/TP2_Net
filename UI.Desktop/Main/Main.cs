using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Alumnos;
using UI.Desktop.Planes_y_Materias;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        int usuario_act_tipo;
        int id_persona_act;

        public formMain()
        {
            InitializeComponent();

        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            LogIn appLogin = new LogIn();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            usuario_act_tipo = appLogin.usuario_actual;
            id_persona_act = appLogin.id_persona_act;
        }

        private void trvABM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodo = e.Node.Name;
            switch (nodo)
            {
                case "nodoUsuario":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        formUsuarios formUsuarios = new formUsuarios();
                        formUsuarios.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoAlumno":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador) // Administrador y Profesor(solo ver)
                    {
                        frmAlumnos formAlumnos = new frmAlumnos();
                        formAlumnos.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoEspecialidad":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmEspecialidades formEspecialidades = new frmEspecialidades();
                        formEspecialidades.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoProfesor": // Profesor (solo ver)
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmProfesores frmProfesores = new frmProfesores();
                        frmProfesores.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoPlan":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmPlanes formplanes = new frmPlanes();
                        formplanes.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoMateria":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmMaterias formmaterias = new frmMaterias();
                        formmaterias.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoComision":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmComisiones formComision = new frmComisiones();
                        formComision.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoCurso":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmCursos formCurso = new frmCursos();
                        formCurso.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoInscripcion":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Alumno)
                    {
                        frmInscripciones formIns = new frmInscripciones(id_persona_act);
                        formIns.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                    
                case "nodoRegistro":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Profesor)
                    {
                        frmRegistroNotas formIns = new frmRegistroNotas();
                        formIns.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case "nodoCursoR":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmReporteCursos formRCurso = new frmReporteCursos();
                        formRCurso.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "nodoPlanR":
                    if (usuario_act_tipo == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        frmReportePlanes formRPlan = new frmReportePlanes();
                        formRPlan.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene acceso", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
        }

        private void AcercaDe_Click_Click(object sender, EventArgs e)
        {
            ShowAcercaDe();
        }

        private void ShowAcercaDe()
        {
            // Crea instancia del dialogo "Acerca de"
            frmAcercaDe ofrmAcercaDe;
            ofrmAcercaDe = new frmAcercaDe();

            // Muestro el formulario de manera modal
            ofrmAcercaDe.ShowDialog();

            // Cierro formulario
            ofrmAcercaDe.Close();

            // Elimino instancia del formulario
            ofrmAcercaDe = null;

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario_act_tipo = 0;
            id_persona_act = 0;

            Main_Shown(sender, e);
        }
    }
}
