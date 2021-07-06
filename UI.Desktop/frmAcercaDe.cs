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
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void frmAcercaDe_Load(object sender, EventArgs e)
        {
            // Set the title of the form.
            this.Text = String.Format("Acerca de Academia");

            // Initialize all of the text displayed on the About Box.
            // TODO: Customize the application's assembly information in the "Application" pane of the project 
            // properties dialog (under the "Project" menu).
            lblNombreProducto.Text = "Academia";
            lblVersion.Text = String.Format("Version {0}", Application.ProductVersion);
            lbEmpresaNombre.Text = "Año: 2021 " + Application.CompanyName;
            lblCopyright.Text = "Desarrollado por:\n Boixadera Loriana, Luna Paulina y Marlene Spitteler";
            txtDescripcion.Text = String.Format("Este producto '{0}' fue desarrollado con fines academicos", Application.ProductName);
                                                

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Retorno al formulario llamador
            this.Hide();

            // Cierra el dialogo
            Close();
        }
    }
}
