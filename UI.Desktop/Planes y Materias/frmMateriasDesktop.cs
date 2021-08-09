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

namespace UI.Desktop.Planes_y_Materias
{
    public partial class frmMateriasDesktop : Form
    {
        public frmMateriasDesktop()
        {
            InitializeComponent();

            MateriaLogic ml = new MateriaLogic();
            cmbPlan.DataSource = ml.GetAll();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
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
