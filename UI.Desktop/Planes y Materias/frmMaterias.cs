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
    public partial class frmMaterias : Form
    {
        public frmMaterias()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            //MateriaDesktop formMateria = new MateriaDesktop(AplicationForm.ModoForm.Alta);
            //formMateria.ShowDialog();
            //this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
