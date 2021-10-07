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
    public partial class Materias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGrid();
                PlanLogic pl = new PlanLogic();
                ddlIdPlan.DataSource = pl.GetAll();
                ddlIdPlan.DataValueField = "ID";
                ddlIdPlan.DataTextField = "Descripcion";
                ddlIdPlan.DataBind();
            }

        }

        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gvMaterias.DataSource = this.Logic.GetAll();
            this.gvMaterias.DataBind();
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

        private Materia Entity { get; set; }

        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }

        protected void gvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvMaterias.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtHsSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txtHsTotales.Text = this.Entity.HSTotales.ToString();
            this.ddlIdPlan.SelectedValue = this.Entity.IDPlan.ToString();
        }

        protected void editarlinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.txtDescripcion.Text;
            materia.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            materia.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            materia.IDPlan = Convert.ToInt32(this.ddlIdPlan.SelectedValue);
        }
        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtHsSemanales.Enabled = enable;
            txtHsTotales.Enabled = enable;
            ddlIdPlan.Enabled = enable;

        }
        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            string msg;
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);

                    msg = "Materia eliminada correctamente.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + msg + "');window.location='Materias.aspx';", true);

                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = new Materia();
                    Entity.ID = this.SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(Entity);
                    this.SaveEntity(Entity);

                    msg = "Materia modificada correctamente.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Materias.aspx';", true);

                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    Entity = new Materia();
                    Entity.State = BusinessEntity.States.New;
                    LoadEntity(Entity);
                    SaveEntity(Entity);

                    msg = "Nueva Materia agregada con éxito.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Materias.aspx';", true);

                    this.LoadGrid();

                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForms();
            EnableForm(true);
        }
        private void ClearForms()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHsSemanales.Text = string.Empty;
            this.txtHsTotales.Text = string.Empty;
            this.ddlIdPlan.SelectedIndex = 0;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }
    }
}