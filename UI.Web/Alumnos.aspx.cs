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
    public partial class Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				this.LoadGrid();
			}
		}

		AlumnoLogic _logic;

		private AlumnoLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new AlumnoLogic();
				}
				return _logic;
			}
		}
		private void LoadGrid()
		{
			this.gvAlumnos.DataSource = this.Logic.GetAll();
			this.gvAlumnos.DataBind();
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

        protected void gvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
			this.SelectedID = (int)this.gvAlumnos.SelectedValue;
        }

		private void LoadForm(int id)
		{
			this.Entity = this.Logic.GetOne(id);
			this.txtNombre.Text = this.Entity.Nombre;
			this.txtApellido.Text = this.Entity.Apellido;
			this.txtLegajo.Text = this.Entity.Legajo.ToString();
			this.txtEmail.Text = this.Entity.Email;
			this.txtDireccion.Text = this.Entity.Direccion;
			this.txtTelefono.Text = this.Entity.Telefono;
			this.dtNacimiento.Text = this.Entity.FechaNacimiento.ToString("dd/MM/yyyy");
			this.ddlIdPlan.SelectedValue = this.Entity.IDPlan.ToString();
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

        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}