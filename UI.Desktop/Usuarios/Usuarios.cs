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
    public partial class formUsuarios : Form
    {
        public formUsuarios()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.AutoGenerateColumns = false;
            try { 
            this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de usuarios" + Ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(AplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, AplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, AplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
                this.Listar();
            }
        }
    }
}


