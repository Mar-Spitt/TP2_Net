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
    public partial class RegistroNotas : Page
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
            this.gvRegistroNotas.AutoGenerateColumns = false;
            this.gvRegistroNotas.DataSource = Logic.GetAll();
            this.gvRegistroNotas.DataBind();
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

        protected void gvRegistroNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvRegistroNotas.SelectedValue;
        }

        private void LoadForm(int id)
        {
            InscripcionLogic inscl = new InscripcionLogic();
            Entity = inscl.GetOne(id);
            this.txtID.Text = Entity.ID.ToString();
            this.txtNombreAlumno.Text = Entity.NombreApellidoAlu.ToString();
            this.txtDescripcionComision.Text = Entity.DescripcionComision.ToString();
            this.txtDescripcionMateria.Text = Entity.DescripcionMateria.ToString();
            this.txtDescripcionCurso.Text = Entity.DescripcionCurso.ToString();
            this.txtAnioCalendario.Text = Entity.AnioCalendario.ToString();
            this.txtCondicion.Text = Entity.Condicion.ToString();
            this.txtNota.Text = Entity.Nota.ToString();

            EnableForm(false);
        }

        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.ID = SelectedID;
            inscripcion.Nota = Convert.ToInt32(this.txtNota.Text);
            inscripcion.Condicion = this.txtCondicion.Text;
        }

        private void EnableForm(bool enable)
        {
            this.txtID.Enabled = enable;
            this.txtNombreAlumno.Enabled = enable;
            this.txtDescripcionCurso.Enabled = enable;
            this.txtDescripcionComision.Enabled = enable;
            this.txtDescripcionMateria.Enabled = enable;
            this.txtDescripcionCurso.Enabled = enable;
            this.txtAnioCalendario.Enabled = enable;
        }

        protected void lnkbtnCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
        }

        protected void lnkbtnAceptar_Click(object sender, EventArgs e)
        {
            string msg;
            this.Entity = new AlumnoInscripcion();
            this.LoadEntity(this.Entity);
            this.SaveEntity(this.Entity);

            msg = "Se registró la Nota y Condición con éxito.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + msg + "');window.location='RegistroNotas.aspx';", true);

            this.formPanel.Visible = false;
        }

        protected void lnkCargarNotaButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.LoadForm(SelectedID);
        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            this.Logic.GuardarNota(inscripcion);
        }

    }
}