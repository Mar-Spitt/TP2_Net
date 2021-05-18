using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.UsuarioNegocio = new UsuarioLogic();
        }

        public UsuarioLogic UsuarioNegocio
        {

            get; set;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "admin")
            //{
            //    MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK,MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            Usuario usu = new Usuario();
            usu = UsuarioNegocio.ValidarUsuario(this.txtUsuario.Text);
            if (usu is null)
            {
                MessageBox.Show("Usuario incorrecto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UsuarioNegocio.ValidarContraseña(usu))
                {
                    MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria. ", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
