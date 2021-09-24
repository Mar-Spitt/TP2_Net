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
    public partial class LogIn : Form
    {
        public int usuario_actual;
        public int id_persona_act;

        public LogIn()
        {
            InitializeComponent();
            this.UsuarioNegocio = new UsuarioLogic();
        }

        public UsuarioLogic UsuarioNegocio{ get; set; }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria. ", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu = UsuarioNegocio.ValidarUsuario(this.txtUsuario.Text);
            if (usu is null)
            {
                MessageBox.Show("Usuario incorrecto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUsuario.Clear();
                this.txtPass.Clear();
            }
            else
            {
                if (UsuarioNegocio.ValidarContraseña(this.txtUsuario.Text, this.txtPass.Text, usu))
                {
                    usuario_actual = (int)usu.TipoPersona;
                    id_persona_act = (int)usu.IdPersona;
                    MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPass.Clear();
                }
            }
        }
        //TODO: analizar si es posible cerrar sesión en escritorio
        private void SeePass_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtPass.Text;
            if (ckbSeePass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = text;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtPass.Text = text;
            }
        }
    }
}
