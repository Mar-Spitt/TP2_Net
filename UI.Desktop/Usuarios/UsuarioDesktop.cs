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
            if(Modo==ModoForm.Alta)
            {
                this.txtLegajo.ReadOnly = false;
            }
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
            this.txtLegajo.Text = this.UsuarioActual.Legajo.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
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
                nuevoUsu.Legajo = int.Parse(this.txtLegajo.Text);
                nuevoUsu.Clave = this.txtClave.Text;
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

            if (this.txtUsuario.Text != String.Empty && this.txtLegajo.Text != String.Empty
                && this.txtClave.Text != String.Empty && this.txtConfirmarClave.Text != String.Empty)
            {
                if (this.txtClave.Text == this.txtConfirmarClave.Text)
                {
                    int cantCarac = this.txtClave.Text.Length;

                    if (cantCarac >= 8)
                    {
                        foreach (char item in this.txtClave.Text)
                        {
                            rta = char.IsWhiteSpace(item);
                            if (rta)
                                break;
                        }

                        if (rta)
                        {
                            Notificar("Contraseña inválida",
                                        "La contraseña no puede contener espacios en blanco",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        }
                        else
                        {
                            rta = true;
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

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
             
            if (Validar())
            {
                    GuardarCambios();
                    this.txtLegajo.ReadOnly = true;
                    this.Close();
            }
            
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.txtLegajo.ReadOnly = true;
            this.Close();
        }

        
    }
}