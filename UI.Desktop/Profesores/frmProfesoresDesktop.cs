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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class frmProfesoresDesktop : AplicationForm
    {
        public frmProfesoresDesktop()
        {
            InitializeComponent();
            PlanLogic pl = new PlanLogic();
            cmbPlan.DataSource = pl.GetAll();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
        }
        public frmProfesoresDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public Persona ProfesorActual { get; set; }
        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.dtpFechaNacimiento.Enabled = enable;
            this.txtID.Enabled = enable;
            this.cmbPlan.Enabled = enable;
        }
        public frmProfesoresDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Baja)
            {
                EnableForm(false);
            }
            ProfesorLogic profe = new ProfesorLogic();
            try
            {
                ProfesorActual = profe.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de profesores" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ProfesorActual.ID.ToString();
            this.txtNombre.Text = this.ProfesorActual.Nombre;
            this.txtApellido.Text = this.ProfesorActual.Apellido;
            this.txtTelefono.Text = this.ProfesorActual.Telefono;
            this.txtEmail.Text = this.ProfesorActual.Email;
            this.dtpFechaNacimiento.Value = this.ProfesorActual.FechaNacimiento;
            this.txtLegajo.Text = this.ProfesorActual.Legajo.ToString();
            this.txtDireccion.Text = this.ProfesorActual.Direccion;
            this.cmbPlan.SelectedValue = this.ProfesorActual.IDPlan;
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
            ProfesorLogic alu = new ProfesorLogic();
            Persona nuevoProfe = new Persona();
            ProfesorActual = nuevoProfe;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoProfe.Nombre = this.txtNombre.Text;
                nuevoProfe.Apellido = this.txtApellido.Text;
                nuevoProfe.Email = this.txtEmail.Text;
                nuevoProfe.FechaNacimiento = this.dtpFechaNacimiento.Value;
                nuevoProfe.Telefono = this.txtTelefono.Text;
                nuevoProfe.Legajo = int.Parse(this.txtLegajo.Text);
                nuevoProfe.Direccion = this.txtDireccion.Text;
                nuevoProfe.IDPlan = int.Parse(this.cmbPlan.SelectedValue.ToString());

                if (Modo == ModoForm.Alta)
                {
                    nuevoProfe.State = BusinessEntity.States.New;
                    alu.Save(nuevoProfe);
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoProfe.ID = int.Parse(this.txtID.Text);
                    nuevoProfe.State = BusinessEntity.States.Modified;
                    alu.Save(nuevoProfe);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoProfe.ID = int.Parse(this.txtID.Text);
                nuevoProfe.State = BusinessEntity.States.Deleted;
                alu.Save(nuevoProfe);
            }
        }
        public override bool Validar()
        {
            bool rta = false;
            if (txtNombre.Text != String.Empty && txtApellido.Text != String.Empty
                && txtDireccion.Text != String.Empty && txtTelefono.Text != String.Empty
                && txtEmail.Text != String.Empty && this.cmbPlan.SelectedValue.ToString() != String.Empty
                && txtLegajo.Text != String.Empty)
            {
                rta = Validaciones.EsMailValido(txtEmail.Text);
                if (!rta)
                {
                    Notificar("Email inválido",
                              "Revise su correo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                }
                else
                {
                    rta = Validaciones.EsFechaNacimientoValida(dtpFechaNacimiento.Value);
                    if (!rta)
                    {
                        Notificar("Fecha inválida",
                                "Revise su fecha de nacimiento",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
                
            }
            else
            {
                Notificar("Ficha de profesor vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
            return rta;
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
    }
}
