using System;
using System.Web.UI;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Comisiones : Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadGrid();

				PlanLogic pl = new PlanLogic();
				ddlIdPlan.DataSource = pl.GetAll();
				ddlIdPlan.DataValueField = "ID";
				ddlIdPlan.DataTextField = "Descripcion";
				ddlIdPlan.DataBind();
			}
		}
		ComisionLogic _logic;

		private ComisionLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new ComisionLogic();
				}
				return _logic;
			}
		}
		private void LoadGrid()
		{
			gvComisiones.DataSource = Logic.GetAll();
			gvComisiones.DataBind();
		}

		public enum FormModes
		{
			Alta,
			Baja,
			Modificacion
		}

		public FormModes FormMode
		{
			get { return (FormModes)ViewState["FormMode"]; }
			set { ViewState["FormMode"] = value; }
		}

		private Comision Entity { get; set; }

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

		protected void gvComisiones_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedID = (int)gvComisiones.SelectedValue;
		}

		private void LoadForm(int id)
		{
			Entity = Logic.GetOne(id);
			txtAnioEspecialidad.Text = Entity.AnioEspecialidad.ToString();
			txtDescripcion.Text = Entity.Descripcion;
			ddlIdPlan.SelectedValue = Entity.IDPlan.ToString();
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

		protected void lnkbtnCancelar_Click(object sender, EventArgs e)
		{
			formPanel.Visible = false;
		}

		protected void lnkbtnAceptar_Click(object sender, EventArgs e)
		{
			string msg;
			switch (FormMode)
			{
				case FormModes.Baja:
					DeleteEntity(SelectedID);

					msg = "Comisión eliminado correctamente.";
					ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + msg + "');window.location='Comisiones.aspx';", true);

					LoadGrid();
					break;
				case FormModes.Modificacion:
					Entity = new Comision();
					Entity.ID = SelectedID;
					Entity.State = BusinessEntity.States.Modified;
					LoadEntity(Entity);
					SaveEntity(Entity);

					msg = "Comisión modificado correctamente.";
					ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + msg + "');window.location='Comisiones.aspx';", true);

					LoadGrid();
					break;
				case FormModes.Alta:
					Entity = new Comision();
					Entity.State = BusinessEntity.States.New;
					LoadEntity(Entity);
					SaveEntity(Entity);

					msg = "Nueva Comisión agregada con éxito.";
					ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + msg + "');window.location='Comisiones.aspx';", true);

					LoadGrid();

					break;
				default:
					break;
			}
			formPanel.Visible = false;
		}

		private void LoadEntity(Comision comision)
		{
			comision.AnioEspecialidad = Convert.ToInt32(txtAnioEspecialidad.Text);
			comision.Descripcion = txtDescripcion.Text;
			comision.IDPlan = Convert.ToInt32(ddlIdPlan.SelectedValue);
		}

		private void SaveEntity(Comision comision)
		{
			Logic.Save(comision);
		}
		private void EnableForm(bool enable)
		{
			txtAnioEspecialidad.Enabled = enable;
			txtDescripcion.Enabled = enable;
			ddlIdPlan.Enabled = enable;
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

		private void DeleteEntity(int id)
		{
			Logic.Delete(id);
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
			txtAnioEspecialidad.Text = string.Empty;
			txtDescripcion.Text = string.Empty;
			ddlIdPlan.SelectedIndex = 0;
		}
	}
}