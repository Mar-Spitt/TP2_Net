using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Valido nombre de usuario y clave
            UsuarioLogic usuarioNegocio = new UsuarioLogic();
            Usuario usu = new Usuario();
            usu = usuarioNegocio.ValidarUsuario(this.txtUsuario.Text); 
            if (usu is null)
            {
                //Page.Response.Write("Usuario incorrecto");
                string msg = "Usuario incorrecto";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Login.aspx';", true);
            }
            else
            {
                if (usuarioNegocio.ValidarContraseña(this.txtUsuario.Text, this.txtContraseña.Text, usu))
                {
                    //Page.Response.Write("Ingreso OK!");
                    Session.Add("usuario", Session.SessionID);
                    string msg = "Usted ha ingresado al sistema correctamente.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+ msg + "');window.location='Home.aspx';", true);
                    //Response.Redirect("Home.aspx");
                }
                else
                {
                    //Page.Response.Write("Contraseña incorrecta");
                    string msg = "Contraseña incorrecta";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Login.aspx';", true);
                }
            }

            
        }
        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx?msj=Es Ud.");
        }
        
    }
}