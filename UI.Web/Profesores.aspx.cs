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
    public partial class Profesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				this.LoadGrid(); //solo en  el primer load de la pagina
				PlanLogic pl = new PlanLogic();
				this.ddlIdPlan.DataSource = pl.GetAll();
				this.ddlIdPlan.DataValueField = "ID";
				this.ddlIdPlan.DataTextField = "Descripcion";
				this.ddlIdPlan.DataBind();
			}
			
		}

		ProfesorLogic _logic;

		private ProfesorLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new ProfesorLogic();
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

		private Persona Entity { get; set; }

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
			this.txtNombre.Text = this.Entity.Nombre;
			this.txtApellido.Text = this.Entity.Apellido;
			this.txtEmail.Text = this.Entity.Email;
			this.txtLegajo.Text = this.Entity.Legajo.ToString();
			this.txtDireccion.Text = this.Entity.Direccion;
			this.txtTelefono.Text = this.Entity.Telefono;
			this.dtNacimiento.Text = this.Entity.FechaNacimiento.ToString("dd/MM/yyyy");
			this.ddlIdPlan.SelectedValue = this.Entity.IDPlan.ToString();
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

		private void LoadEntity(Persona persona)
		{
			persona.Nombre = this.txtNombre.Text;
			persona.Apellido = this.txtApellido.Text;
			persona.Direccion = this.txtDireccion.Text;
			persona.Email = this.txtEmail.Text;
			persona.Legajo = int.Parse(this.txtLegajo.Text);
			persona.Telefono = this.txtTelefono.Text;
			persona.FechaNacimiento = Convert.ToDateTime(this.dtNacimiento.Text);
			persona.IDPlan = Convert.ToInt32(this.ddlIdPlan.SelectedValue);
		}

		private void SaveEntity(Persona persona)
		{
			this.Logic.Save(persona);
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

					msg = "Profesor eliminado correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Profesores.aspx';", true);

					this.LoadGrid();
					break;
				case FormModes.Modificacion:
					this.Entity = new Persona();
					this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);

					msg = "Profesor modificado correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Profesores.aspx';", true);

					this.LoadGrid();
					break;
				case FormModes.Alta:
					this.Entity = new Persona();
					this.Entity.State = BusinessEntity.States.New;
					this.LoadEntity(this.Entity);
					this.Entity.TipoPersona = Persona.TiposPersonas.Profesor;
					this.SaveEntity(this.Entity);

					msg = "Nuevo profesor agregado con éxito.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Profesores.aspx';", true);

					this.LoadGrid();

					break;
				default:
					break;
			}
			this.formPanel.Visible = false;
		}

		private void EnableForm(bool enable)
		{
			this.txtNombre.Enabled = enable;
			this.txtApellido.Enabled = enable;
			this.txtDireccion.Enabled = enable;
			this.txtEmail.Enabled = enable;
			this.txtLegajo.Enabled = enable;
			this.txtTelefono.Enabled = enable;
			this.dtNacimiento.Enabled = enable;
			this.ddlIdPlan.Enabled = enable;
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

		private void DeleteEntity(int id)
		{
			this.Logic.Delete(id);
		}
		protected void lnkbtnNuevo_Click(object sender, EventArgs e)
		{
			this.formPanel.Visible = true;
			this.FormMode = FormModes.Alta;
			this.ClearForms();
			this.EnableForm(true);
		}
		private void ClearForms()
		{
			this.txtNombre.Text = string.Empty;
			this.txtApellido.Text = string.Empty;
			this.txtEmail.Text = string.Empty;
			this.txtLegajo.Text = string.Empty;
			this.txtDireccion.Text = string.Empty;
			this.txtTelefono.Text = string.Empty;
			this.dtNacimiento.Text = string.Empty;
			this.ddlIdPlan.SelectedIndex = 0;
		}
	}
}