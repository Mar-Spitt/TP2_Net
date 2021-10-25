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
	public partial class Especialidades : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.LoadGrid();
			}

		}

		EspecialidadLogic _logic;

		private EspecialidadLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new EspecialidadLogic();
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

		private Especialidad Entity { get; set; }

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
		}

		private void EnableForm(bool enable)
		{
			this.txtDescripcion.Enabled = enable;
		}

		protected void lnkbtnEditar_Click(object sender, EventArgs e)
		{
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Modificacion;
				this.LoadForm(this.SelectedID);
			}
		}

		protected void lnkbtnEliminar_Click(object sender, EventArgs e)
		{
			if (this.IsEntitySelected)
			{
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Baja;
				this.EnableForm(false);
				this.LoadForm(this.SelectedID);
			}
		}
		protected void lnkbtnNuevo_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForms();
			this.EnableForm(true);
		}

		protected void lnkbtnCancelar_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = false;
		}


		private void LoadEntity(Especialidad especialidad)
        {
			especialidad.Descripcion = this.txtDescripcion.Text;
        }

		private void DeleteEntity(int id)
        {
			this.Logic.Delete(id);
        }
		private void SaveEntity(Especialidad especialidad)
        {
			this.Logic.Save(especialidad);
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
			string msg;
			switch (this.FormMode)
			{
				case FormModes.Baja:
					this.DeleteEntity(this.SelectedID);

					msg = "Especialidad eliminada correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Especialidades.aspx';", true);

					this.LoadGrid();
					break;

				case FormModes.Modificacion:
					this.Entity = new Especialidad();
					this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);

					msg = "Especialidad modificada correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Especialidades.aspx';", true);

					this.LoadGrid();
					break;

				case FormModes.Alta:
					this.Entity = new Especialidad();
					this.Entity.State = BusinessEntity.States.New;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);

					msg = "Nuevo especialidad agregada con éxito.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Especialidades.aspx';", true);

					this.LoadGrid();

					break;
				default:
					break;
			}
			this.formPanel.Visible = false;
		}
		private void ClearForms()
		{
			this.txtDescripcion.Text = string.Empty;
		}
	}
}