using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				this.LoadGrid(); //solo en  el primer load de la pagina
            }
            else
            {
				
				//se ejecuta en cada request
			}
        }

		UsuarioLogic _logic;

		private UsuarioLogic Logic
		{
			get
			{
				if (_logic == null)
				{
					_logic = new UsuarioLogic();
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

		private Usuario Entity { get; set; }

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
			this.txtLegajo.Text = this.Entity.Legajo.ToString();
			this.txtEmail.Text = this.Entity.Email;
			this.chkHabilitado.Checked = this.Entity.Habilitado;
			this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
		}

        protected void lnkbtnEditar_Click(object sender, EventArgs e)
        {
			if (this.IsEntitySelected)
			{
				this.EnableForm(true);
				this.formPanel.Visible = true;
				this.FormMode = FormModes.Modificacion;
				this.txtLegajo.Enabled = false;
				this.txtNombre.Enabled = false;
				this.txtApellido.Enabled = false;
				this.txtEmail.Enabled = false;
				this.LoadForm(this.SelectedID);
			}
		}

		private void LoadEntity(Usuario usuario)
		{
			//usuario.Nombre = this.txtNombre.Text;
			//usuario.Apellido = this.txtApellido.Text;
			//usuario.Email = this.txtEmail.Text;
			usuario.NombreUsuario = this.txtNombreUsuario.Text;
			usuario.Clave = this.txtClave.Text;
			usuario.Habilitado = this.chkHabilitado.Checked;
		}

		private void SaveEntity(Usuario usuario)
		{
			UsuarioLogic usuLogic = new UsuarioLogic();
			Usuario usu = usuLogic.GetOne(usuario.ID);
			usuario.IdPersona = usu.IdPersona;
			this.Logic.Save(usuario);
		}

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
			switch (this.FormMode)
			{
				case FormModes.Baja:
					this.DeleteEntity(this.SelectedID);
					this.LoadGrid();
					break;
				case FormModes.Modificacion:
					this.Entity = new Usuario();
					this.Entity.ID = this.SelectedID;
					this.Entity.State = BusinessEntity.States.Modified;
					this.LoadEntity(this.Entity);
					this.SaveEntity(this.Entity);
					this.LoadGrid();
                    break;
                case FormModes.Alta: //TODO agregar messagebox para confimar que se registró, modificó o eliminó con exito
					//agregar messagebox + excepción si no se encuentra la persona indicada para agregarle el usuario
                    this.Entity = new Usuario();
					Entity.Legajo = Convert.ToInt32(this.txtLegajo.Text);
					PersonaLogic perLo = new PersonaLogic();
					Persona per = new Persona();
					per = perLo.GetOne(Entity.Legajo);
					if(per!=null)
                    {
						Entity.IdPersona = per.ID;
						Entity.State = BusinessEntity.States.New;
						this.LoadEntity(this.Entity);
						//this.SaveEntity(this.Entity);
						UsuarioLogic usuLogic = new UsuarioLogic();
						this.Logic.Save(Entity);
						this.LoadGrid();
					}
					
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
			this.txtLegajo.Enabled = enable;
			this.txtEmail.Enabled = enable;
			this.txtNombreUsuario.Enabled = enable;
			this.txtClave.Visible = enable;
			this.lblClave.Visible = enable;
			this.txtRepetirClave.Visible = enable;
			this.lblRepetirClave.Visible = enable;
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
			this.txtLegajo.Text = string.Empty;
			this.txtEmail.Text = string.Empty;
			this.chkHabilitado.Checked = false;
			this.txtNombreUsuario.Text = string.Empty;
		}

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
			this.formPanel.Visible = false;
        }
    }
}