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
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				this.LoadGrid();
				EspecialidadLogic el = new EspecialidadLogic();
				this.ddlIdEspecialidad.DataSource = el.GetAll();
				this.ddlIdEspecialidad.DataValueField = "ID";
				this.ddlIdEspecialidad.DataTextField = "Descripcion";
				this.ddlIdEspecialidad.DataBind();
			}
		}

		PlanLogic _logic;

		private PlanLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new PlanLogic();
				}
				return _logic;
			}
		}
		private void LoadGrid()
		{
			this.gridView.DataSource = this.Logic.GetAll();
			this.gridView.DataBind();
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

		private Plan Entity { get; set; }

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

		protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedID = (int)this.gridView.SelectedValue;
		}

		private void LoadForm(int id)
		{
			this.Entity = this.Logic.GetOne(id);
			this.txtDescripcion.Text = this.Entity.Descripcion;
			this.ddlIdEspecialidad.SelectedValue = this.Entity.IDEspecialidad.ToString();
		}

		protected void editarlinkButton_Click(object sender, EventArgs e)
		{
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Modificacion;
				this.LoadForm(this.SelectedID);
			}
		}

		protected void lnkbtnCancelar_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = false;
		}

		protected void lnkbtnAceptar_Click(object sender, EventArgs e)
		{
			string msg;
			switch (this.FormMode)
			{
				case FormModes.Baja:
					this.DeleteEntity(this.SelectedID);

					msg = "Plan eliminado correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Planes.aspx';", true);

					this.LoadGrid();
					break;
				case FormModes.Modificacion:
					this.Entity = new Plan();
					this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);

					msg = "Plan modificado correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Planes.aspx';", true);

					this.LoadGrid();
					break;
				case FormModes.Alta:
					this.Entity = new Plan();
					this.Entity.State = BusinessEntity.States.New;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);

					msg = "Nuevo plan agregado con éxito.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Planes.aspx';", true);

					this.LoadGrid();

					break;
				default:
					break;
			}
			this.formPanel.Visible = false;
		}

		private void LoadEntity(Plan plan)
		{
			plan.Descripcion = this.txtDescripcion.Text;
			plan.IDEspecialidad = Convert.ToInt32(this.ddlIdEspecialidad.SelectedValue);
		}

		private void SaveEntity(Plan plan)
		{
			this.Logic.Save(plan);
		}
		private void EnableForm(bool enable)
		{
			this.txtDescripcion.Enabled = enable;
			this.ddlIdEspecialidad.Enabled = enable;
		}

		protected void eliminarLinkButton_Click(object sender, EventArgs e)
		{
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Baja;
				this.EnableForm(false);
				this.LoadForm(this.SelectedID);
			}
		}

		private void DeleteEntity(int id)
		{
			this.Logic.Delete(id);
		}

		protected void nuevoLinkButton_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForms();
			this.EnableForm(true);
		}
		private void ClearForms()
		{
			this.txtDescripcion.Text = string.Empty;
			this.ddlIdEspecialidad.SelectedIndex = 0;
		}

	}
}