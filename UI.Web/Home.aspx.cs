using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            string nodo = TreeView1.SelectedValue;

            switch (nodo)
            {
                case "nodoUsuarios":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Usuarios.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoAlumnos":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Alumnos.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoEspecialidades":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Especialidades.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoProfesores":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Profesores.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoPlanes":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Planes.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoComisiones":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Comisiones.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoCursos":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Cursos.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoMaterias":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/Materias.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoInscripciones":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Alumno)
                    {
                        Response.Redirect("");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoNotas":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Profesor)
                    {
                        Response.Redirect("");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoRCursos":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/ReporteCursos.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
                case "nodoRPlanes":
                    if (Convert.ToInt32(Session["usuario_actual"]) == (int)Business.Entities.Persona.TiposPersonas.Administrador)
                    {
                        Response.Redirect("~/ReportePlanes.aspx");
                    }
                    else
                    {
                        string msg = "Usted no tiene acceso";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Home.aspx';", true);
                    }
                    break;
            }

        }


    }
}