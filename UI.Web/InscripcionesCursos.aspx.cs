using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

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

        protected void gvInscripcionesCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvInscripcionesCursos.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.txtIdAlumno.Text = Session["id_persona_act"].ToString();
            this.txtIdCurso.Text = id.ToString();//SelectedID.ToString();

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
            inscripcion.IDAlumno = Convert.ToInt32(Session["id_persona_act"]);
            inscripcion.Condicion = "";
        }


        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            this.Entity = new AlumnoInscripcion();
            LoadEntity(Entity);
            if (Logic.Existe(Entity) == true)
            {
                string msj = "Usted ya se encuentra registrado";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msj + "');window.location='InscripcionesCursos.aspx';", true);
            }
            else
            {
                CursoLogic cl = new CursoLogic();
                Curso nuevoCur = cl.GetOne(Entity.IDCurso);

                if (nuevoCur.Cupo > 0)
                {
                    string msj = "Su inscripción ha sido registrada con éxito";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msj + "');window.location='InscripcionesCursos.aspx';", true);
                    nuevoCur.Cupo = nuevoCur.Cupo - 1;
                    nuevoCur.State = BusinessEntity.States.Modified;
                    cl.Save(nuevoCur); //Se actualiza cupo del curso

                    this.Entity.State = BusinessEntity.States.New;
                    
                    this.SaveEntity(this.Entity);

                    this.formPanel.Visible = false;
                }
                else
                {
                    string msj = "No se ha podido registrar su inscripcion porque el curso no tiene cupos.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msj + "');window.location='InscripcionesCursos.aspx';", true);
                }
            }
        }

        protected void inscribirlinkButton_Click(object sender, EventArgs e)
        {
            if (SelectedID == 0)
            {
                string msj = "Por favor seleccione un Curso.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msj + "');window.location='InscripcionesCursos.aspx';", true);
            }
            else
            {
                this.formPanel.Visible = true;
                this.LoadForm(SelectedID);
            }
        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            this.Logic.Save(inscripcion);
        }

    }
}