using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

// TODO: Validar que el usuario logeado sea un Alumno para ingresar
namespace UI.Web
{
    public partial class InscripcionesCursos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
            }
        }

        InscripcionLogic _logic;

        private InscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new InscripcionLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            CursoLogic cl = new CursoLogic();
            this.gvInscripcionesCursos.AutoGenerateColumns = false;
            this.gvInscripcionesCursos.DataSource = cl.GetAllAnioActual();
            this.gvInscripcionesCursos.DataBind();
        }

        private AlumnoInscripcion Entity { get; set; }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gvInscripcionesCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvInscripcionesCursos.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.txtIdAlumno.Text = Session["id_persona_act"].ToString();
            this.txtIdCurso.Text = SelectedID.ToString();

            CursoLogic cl = new CursoLogic();
            Curso cur = cl.GetOne(SelectedID);
            this.txtDescripcionCurso.Text = cur.Descripcion;
            
            AlumnoLogic al = new AlumnoLogic();
            Persona per = al.GetOne(Convert.ToInt32(Session["id_persona_act"]));
            this.txtNombreAlumno.Text = per.Nombre+" "+per.Apellido;

        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.IDCurso = Convert.ToInt32(this.txtIdCurso.Text);
            inscripcion.IDAlumno = Convert.ToInt32(Session["usuario_actual"]);
            inscripcion.Condicion = " ";
        }


        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            string msg;
            this.Entity = new AlumnoInscripcion();
            this.Entity.State = BusinessEntity.States.New;
            this.LoadEntity(this.Entity);
            this.SaveEntity(this.Entity);

            msg = "Nueva inscripcion agregada con éxito.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='InscripcionesCursos.aspx';", true);

            this.formPanel.Visible = false;
        }

        protected void inscribirlinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.LoadForm(SelectedID);

        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            this.Logic.Save(inscripcion);
        }

    }
}