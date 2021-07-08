using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Planes_y_Materias
{
    public partial class frmMateriasDesktop : Form
    {
        public frmMateriasDesktop()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (Validar())
            //{
            //    GuardarCambios();
            //    this.Close();
            //}
        }
    }
}
