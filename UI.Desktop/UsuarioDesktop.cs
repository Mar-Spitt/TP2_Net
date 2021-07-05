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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : AplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic usr = new UsuarioLogic();
            try 
            { 
                UsuarioActual = usr.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {  
                Notificar("Error", "Error al recuperar lista de usuarios" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            UsuarioLogic usr = new UsuarioLogic();
            Usuario nuevoUsu = new Usuario();
            UsuarioActual = nuevoUsu;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoUsu.Nombre = this.txtNombre.Text;
                nuevoUsu.Apellido = this.txtApellido.Text;
                nuevoUsu.Clave = this.txtClave.Text;
                nuevoUsu.EMail = this.txtEmail.Text;
                nuevoUsu.NombreUsuario = this.txtUsuario.Text;
                nuevoUsu.Habilitado = this.chkHabilitado.Checked;

                if (Modo == ModoForm.Alta)
                {
                    nuevoUsu.State = BusinessEntity.States.New;
                    usr.Save(nuevoUsu);
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoUsu.ID = int.Parse(this.txtID.Text);
                    nuevoUsu.State = BusinessEntity.States.Modified;
                    usr.Save(nuevoUsu);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoUsu.ID = int.Parse(this.txtID.Text);
                nuevoUsu.State = BusinessEntity.States.Deleted;
                usr.Save(nuevoUsu);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
        }

        public override bool Validar()
        {
            bool rta = false;

            if (txtUsuario.Text != String.Empty && txtNombre.Text != String.Empty
                && txtApellido.Text != String.Empty && txtClave.Text != String.Empty
                && txtConfirmarClave.Text != String.Empty && txtEmail.Text != String.Empty)
            {
                if (txtClave.Text == txtConfirmarClave.Text)
                {
                    int cantCarac = txtClave.Text.Length;

                    if (cantCarac >= 8)
                    {
                        foreach (char item in txtClave.Text)
                        {
                            rta = char.IsWhiteSpace(item);
                            if (rta)
                                break;
                        }

                        if (!rta)
                        {
                            rta = validarEmail(txtEmail.Text);
                            if (!rta)
                            {
                                Notificar("Email inválido",
                                          "Revise su correo",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Notificar("Contraseña inválida",
                                         "La contraseña no puede contener espacios en blanco",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Notificar("Contraseña inválida",
                                         "La contraseña al menos 8 caracteres",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Notificar("Contraseña inválida",
                                         "El campo Clave no coincide con el campo Confirmar Clave",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                }
            }
            else
            {
                Notificar("Ficha de usuario vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }

            return rta;
        }

        public Usuario UsuarioActual { get; set; }

        public static bool validarEmail(string email)
        {
            String expresion;
            bool rta2 = false;
            expresion = @"\A(\w+.?\w*@\w+.)(com)\Z";


            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    rta2 = true;
                }
            }
            return rta2;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}