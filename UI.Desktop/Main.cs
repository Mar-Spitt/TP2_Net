using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
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
        }

        private void trvABM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodo = e.Node.Name;
            switch (nodo)
            {
                case "nodoUsuario":
                    formUsuarios formUsuarios = new formUsuarios();
                    formUsuarios.ShowDialog();
                    break;
                case "nodoAlumno":

                    break;
                case "nodoEspecialidad":

                    break;
                case "nodoProfesor":

                    break;
                case "nodoPlanMateria":

                        break;
                case "nodoComision":

                    break;
                case "nodoCurso":

                    break;
                case "nodoInscripcion":

                    break;
                case "nodoRegistro":

                    break;
                case "nodoCursoR":

                    break;
                case "nodoPlanR":

                    break;

            }
        }
    }
}
