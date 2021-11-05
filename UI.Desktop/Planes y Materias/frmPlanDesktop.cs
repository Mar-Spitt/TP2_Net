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
    public partial class frmPlanDesktop : AplicationForm
    {
        public frmPlanDesktop()
        {
            InitializeComponent();
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidad.DataSource = el.GetAll();
            cmbEspecialidad.ValueMember = "ID";
            cmbEspecialidad.DisplayMember = "Descripcion";
        }

        public frmPlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Plan PlanActual { get; set; }
        private void EnableForm(bool enable)
        {
            this.txtId.Enabled = enable;
            this.txtPlan.Enabled = enable;
            this.cmbEspecialidad.Enabled = enable;
        }

        public frmPlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Baja)
            {
                EnableForm(false);
            }
            PlanLogic pl = new PlanLogic();
            try
            {
                PlanActual = pl.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de planes" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.PlanActual.ID.ToString();
            this.txtPlan.Text = this.PlanActual.Descripcion;
            this.cmbEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;


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
                PlanLogic pl = new PlanLogic();
                Plan nuevoPlan = new Plan();
                PlanActual = nuevoPlan;

                if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
                {
                    nuevoPlan.Descripcion = this.txtPlan.Text;
                    nuevoPlan.IDEspecialidad = int.Parse(this.cmbEspecialidad.SelectedValue.ToString());

                    if (Modo == ModoForm.Alta)
                    {
                        nuevoPlan.State = BusinessEntity.States.New;
                        pl.Save(nuevoPlan);
                    }

                    if (Modo == ModoForm.Modificacion)
                    {
                        nuevoPlan.ID = int.Parse(this.txtId.Text);
                        nuevoPlan.State = BusinessEntity.States.Modified;
                        pl.Save(nuevoPlan);
                    }
                }

                if (Modo == ModoForm.Baja)
                {
                    nuevoPlan.ID = int.Parse(this.txtId.Text);
                    nuevoPlan.State = BusinessEntity.States.Deleted;
                    pl.Save(nuevoPlan);
                }
            }
            catch (Exception Ex)
            {
                Notificar("Error",
                          "Se producido un error al conectar con la base de datos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public override bool Validar()
        {
            bool rta = false;
            if (this.txtPlan.Text != String.Empty && this.cmbEspecialidad.SelectedValue.ToString() != String.Empty)
            {
                rta = true;
            }
            else
            {
                Notificar("Ficha de plan vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
            return rta;
        }

        private void frmPlanDesktop_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tP2_AcademiaDataSet.especialidades' Puede moverla o quitarla según sea necesario.
            this.especialidadesTableAdapter.Fill(this.tP2_AcademiaDataSet.especialidades);

        }
    }
}
