using System;
using System.Web.UI;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Cursos : Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadGrid();

				MateriaLogic ml = new MateriaLogic();
				ddlIdMateria.DataSource = ml.GetAll();
				ddlIdMateria.DataValueField = "ID";
				ddlIdMateria.DataTextField = "Descripcion";
				ddlIdMateria.DataBind();

				ComisionLogic cl = new ComisionLogic();
				ddlIdComision.DataSource = cl.GetAll();
				ddlIdComision.DataValueField = "ID";
				ddlIdComision.DataTextField = "Descripcion";
				ddlIdComision.DataBind();
			}
		}

		CursoLogic _logic;

		private CursoLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new CursoLogic();
				}
				return _logic;
			}
		}
		private void LoadGrid()
		{
			gvCursos.DataSource = Logic.GetAll();
			gvCursos.DataBind();
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

		private Curso Entity { get; set; }

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

		protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedID = (int)gvCursos.SelectedValue;
		}

		private void LoadForm(int id)
		{
			Entity = Logic.GetOne(id);
			txtDescripcion.Text = Entity.Descripcion;
			txtCupo.Text = Convert.ToString(Entity.Cupo);
			txtAnioCalendario.Text = Entity.AnioCalendario.ToString();
			ddlIdComision.SelectedValue = Entity.IDComision.ToString();
			ddlIdMateria.SelectedValue = Entity.IDMateria.ToString();
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

					msg = "Curso eliminado correctamente.";
					ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('" + msg + "');window.location='Cursos.aspx';", true);

					LoadGrid();
					break;
				case FormModes.Modificacion:
					Entity = new Curso();
					Entity.ID = this.SelectedID;
					Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(Entity);
					this.SaveEntity(Entity);

					msg = "Curso modificado correctamente.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Cursos.aspx';", true);

					this.LoadGrid();
					break;
				case FormModes.Alta:
					Entity = new Curso();
					Entity.State = BusinessEntity.States.New;
					LoadEntity(Entity);
					SaveEntity(Entity);

					msg = "Nuevo Curso agregado con éxito.";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='Cursos.aspx';", true);

					this.LoadGrid();

					break;
				default:
					break;
			}
			this.formPanel.Visible = false;
		}

		private void LoadEntity(Curso curso)
		{
			curso.Descripcion = txtDescripcion.Text;
			curso.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);
			curso.Cupo = Convert.ToInt32(txtCupo.Text);
			curso.IDComision = Convert.ToInt32(ddlIdComision.SelectedValue);
			curso.IDMateria = Convert.ToInt32(ddlIdMateria.SelectedValue);
		}

		private void SaveEntity(Curso curso)
		{
			this.Logic.Save(curso);
		}
		private void EnableForm(bool enable)
		{
			txtDescripcion.Enabled = enable;
			txtAnioCalendario.Enabled = enable;
			txtCupo.Enabled = enable;
			ddlIdComision.Enabled = enable;
			ddlIdMateria.Enabled = enable;
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
			txtDescripcion.Text = string.Empty;
			txtAnioCalendario.Text = string.Empty;
			txtCupo.Text = string.Empty;
			ddlIdComision.SelectedIndex = 0;
			ddlIdMateria.SelectedIndex = 0;
		}
	}
}