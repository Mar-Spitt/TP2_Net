using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class frmComisionesDesktop : AplicationForm
    {
        public frmComisionesDesktop()
        {
            InitializeComponent();
            PlanLogic co = new PlanLogic();
            cmbDescipcionPlan.DataSource = co.GetAll();
            cmbDescipcionPlan.ValueMember = "ID";
            cmbDescipcionPlan.DisplayMember = "Descripcion";
        }

        public frmComisionesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        private void EnableForm(bool enable)
        {
            this.txtID.Enabled = enable;
            this.txtDescipcion.Enabled = enable;
            this.txtAnioEspecialidad.Enabled = enable;
            this.cmbDescipcionPlan.Enabled = enable;
        }

        public Comision ComisionActual { get; set; }

        public frmComisionesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if(modo == ModoForm.Baja)
            {
                EnableForm(false);
            }
            ComisionLogic co = new ComisionLogic();
            try
            {
                ComisionActual = co.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de comisiones" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cmbDescipcionPlan.SelectedValue = this.ComisionActual.IDPlan;
            this.txtDescipcion.Text = this.ComisionActual.Descripcion;

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            try
            {
                ComisionLogic co = new ComisionLogic();
                Comision nuevaComision = new Comision();
                ComisionActual = nuevaComision;

                if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
                {
                    nuevaComision.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                    nuevaComision.IDPlan = int.Parse(this.cmbDescipcionPlan.SelectedValue.ToString());
                    nuevaComision.Descripcion = this.txtDescipcion.Text;
                    
                    if (Modo == ModoForm.Alta)
                    {
                        nuevaComision.State = BusinessEntity.States.New;
                        co.Save(nuevaComision);
                    }

                    if (Modo == ModoForm.Modificacion)
                    {
                        nuevaComision.ID = int.Parse(this.txtID.Text);
                        nuevaComision.State = BusinessEntity.States.Modified;
                        co.Save(nuevaComision);
                    }
                }

                if (Modo == ModoForm.Baja)
                {
                    nuevaComision.ID = int.Parse(this.txtID.Text);
                    nuevaComision.State = BusinessEntity.States.Deleted;
                    co.Save(nuevaComision);
                }
            }
            catch (Exception Ex)
            {
                Notificar("Error",
                          "Se producido un error al conectar con la base de datos: "+Ex,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public override bool Validar()
        {
            bool rta = false;
            if (this.txtAnioEspecialidad.Text != String.Empty && this.cmbDescipcionPlan.SelectedValue.ToString() != String.Empty
                && this.txtDescipcion.Text != String.Empty)
            {
                rta = true;
            }
            else
            {
                Notificar("Ficha de comisión vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
            return rta;
        }

    }
}
