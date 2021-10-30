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

                // se cargan los controles del form
                ComisionLogic cl = new ComisionLogic();
                ddlIDComision.DataSource = cl.GetAll();
                ddlIDComision.DataTextField = "Descripcion";
                ddlIDComision.DataValueField = "ID";
                ddlIDComision.DataBind();

                CursoLogic curl = new CursoLogic();
                ddlIDComision.DataSource = curl.GetAll();
                ddlIDComision.DataTextField = "Descripcion";
                ddlIDComision.DataValueField = "ID";
                ddlIDComision.DataBind();

                MateriaLogic mateL = new MateriaLogic();
                ddlIDMateria.DataSource = mateL.GetAll();
                ddlIDMateria.DataTextField = "Descripcion";
                ddlIDMateria.DataValueField = "ID";
                ddlIDMateria.DataBind();
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlIDComision = e.Row.FindControl("ddlIDComision") as DropDownList;
                DropDownList ddlIDMateria = e.Row.FindControl("ddlIDMateria") as DropDownList;

                ComisionLogic cl = new ComisionLogic();
                ddlIDComision.DataSource = cl.GetAll();
                ddlIDComision.DataTextField = "Descripcion";
                ddlIDComision.DataValueField = "ID";
                ddlIDComision.DataBind();

                MateriaLogic mateL = new MateriaLogic();
                ddlIDMateria.DataSource = mateL.GetAll();
                ddlIDMateria.DataTextField = "Descripcion";
                ddlIDMateria.DataValueField = "ID";
                ddlIDMateria.DataBind();

                //Selecciona la comision en DropDownList
                //string comision = ((TextBox)e.Row.FindControl("txtComision")).Text;
                //ddlIDComision.Items.FindByValue(comision).Selected = true;

                //string materia = (e.Row.FindControl("txtDescMateria") as TextBox).Text;
                //ddlIDMateria.Items.FindByValue(materia).Selected = true;
            }
        }

        private void LoadGrid()
        {
            CursoLogic cl = new CursoLogic();
            this.gvInscripcionesCursos.AutoGenerateColumns = false;
            this.gvInscripcionesCursos.DataSource = cl.GetAllAnioActual();
            

            this.gvInscripcionesCursos.DataBind();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
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

        //private void LoadForm(int id)
        //{
        //    // TODO: Ver Método

        //    AlumnoInscripcion ai = 

        //    //this.Entity = this.Logic.GetOne(id);

        //    CursoLogic ins = new CursoLogic();
        //    //this.gvInscripcionesCursos.DataSource = ins.GetAllAnioActual();

        //    this.ddlIDCurso.SelectedValue = this.Entity.IDCurso.ToString();
        //    //this.ddlIDMateria.SelectedValue = this.Entity.IDMateria.ToString();
        //    //this.ddlIDComision.SelectedValue = this.Entity.ddlIDComision.ToString();
        //    //this.txtEmail.Text = this.Entity.Email;
        //}

        protected void editarlinkButton_Click(object sender, EventArgs e)
        {
            //    if (this.IsEntitySelected)
            //    {
            //        this.formPanel.Visible = true;
            //        this.FormMode = FormModes.Modificacion;
            //        this.LoadForm(this.SelectedID);
            //    }
        }

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            //    this.formPanel.Visible = false;
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            //    string msg;
            //    switch (this.FormMode)
            //    {
            //        case FormModes.Baja:
            //            this.DeleteEntity(this.SelectedID);

            //            msg = "Alumno eliminado correctamente.";
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Alumnos.aspx';", true);

            //            this.LoadGrid();
            //            break;
            //        case FormModes.Modificacion:
            //            this.Entity = new Persona();
            //            this.Entity.ID = this.SelectedID;
            //            this.Entity.State = BusinessEntity.States.Modified;
            //            this.LoadEntity(this.Entity);
            //            this.SaveEntity(this.Entity);

            //            msg = "Alumno modificado correctamente.";
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Alumnos.aspx';", true);

            //            this.LoadGrid();
            //            break;
            //        case FormModes.Alta:
            //            this.Entity = new Persona();
            //            this.Entity.State = BusinessEntity.States.New;
            //            this.LoadEntity(this.Entity);
            //            this.Entity.TipoPersona = Persona.TiposPersonas.Alumno;
            //            this.SaveEntity(this.Entity);

            //            msg = "Nuevo alumno agregado con éxito.";
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Alumnos.aspx';", true);

            //            this.LoadGrid();

            //            break;
            //        default:
            //            break;
            //    }
            //    this.formPanel.Visible = false;
        }

        //private void LoadEntity(Persona persona)
        //{
        //    persona.Nombre = this.txtNombre.Text;
        //    persona.Apellido = this.txtApellido.Text;
        //    persona.Direccion = this.txtDireccion.Text;
        //    persona.Email = this.txtEmail.Text;
        //    persona.Legajo = int.Parse(this.txtLegajo.Text);
        //    persona.Telefono = this.txtTelefono.Text;
        //    persona.FechaNacimiento = Convert.ToDateTime(this.dtNacimiento.Text);
        //    persona.IDPlan = Convert.ToInt32(this.ddlIdPlan.SelectedValue);
        //}

        //private void SaveEntity(Persona persona)
        //{
        //    this.Logic.Save(persona);
        //}
        //private void EnableForm(bool enable)
        //{
        //    this.txtNombre.Enabled = enable;
        //    this.txtApellido.Enabled = enable;
        //    this.txtDireccion.Enabled = enable;
        //    this.txtEmail.Enabled = enable;
        //    this.txtLegajo.Enabled = enable;
        //    this.txtTelefono.Enabled = enable;
        //    this.dtNacimiento.Enabled = enable;
        //    this.ddlIdPlan.Enabled = enable;
        //}

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            //    if (this.IsEntitySelected)
            //    {
            //        this.formPanel.Visible = true;
            //        this.FormMode = FormModes.Baja;
            //        this.EnableForm(false);
            //        this.LoadForm(this.SelectedID);
            //    }
        }

        //private void DeleteEntity(int id)
        //{
        //    this.Logic.Delete(id);
        //}

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            //    this.formPanel.Visible = true;
            //    this.FormMode = FormModes.Alta;
            //    this.ClearForms();
            //    this.EnableForm(true);
            //}
            //private void ClearForms()
            //{
            //    this.txtNombre.Text = string.Empty;
            //    this.txtApellido.Text = string.Empty;
            //    this.txtLegajo.Text = string.Empty;
            //    this.txtEmail.Text = string.Empty;
            //    this.txtDireccion.Text = string.Empty;
            //    this.txtTelefono.Text = string.Empty;
            //    this.ddlIdPlan.SelectedIndex = 0;
            //    this.dtNacimiento.Text = string.Empty;
        }
    }
}