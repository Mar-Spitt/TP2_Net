using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using UI.Desktop;
using System.Text.RegularExpressions;

namespace UI.Desktop.Alumnos
{
    public partial class frmAlumnosDesktop : AplicationForm
    {
        public frmAlumnosDesktop()
        {
            InitializeComponent();
            PlanLogic ml = new PlanLogic();
            cmbPlan.DataSource = ml.GetAll();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
        }
        public frmAlumnosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public Persona AlumnoActual { get; set; }
        private void Enable(bool enable)
        {
            this.txtID.Enabled = enable;
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.dtNacimiento.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.cmbPlan.Enabled = enable;
        }
        public frmAlumnosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if(modo == ModoForm.Baja)
            {
                Enable(false);
            }
            AlumnoLogic alu = new AlumnoLogic();
            try
            {
                AlumnoActual = alu.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de alumnos" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlumnoActual.ID.ToString();
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtTelefono.Text = this.AlumnoActual.Telefono;
            this.txtEmail.Text = this.AlumnoActual.Email;
            this.dtNacimiento.Value = this.AlumnoActual.FechaNacimiento;
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();
            this.txtDireccion.Text = this.AlumnoActual.Direccion;
            this.cmbPlan.SelectedValue = this.AlumnoActual.IDPlan;
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
            AlumnoLogic alu = new AlumnoLogic();
            Persona nuevoAlu = new Persona();
            AlumnoActual = nuevoAlu;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoAlu.Nombre = this.txtNombre.Text;
                nuevoAlu.Apellido = this.txtApellido.Text;
                nuevoAlu.Email = this.txtEmail.Text;
                nuevoAlu.FechaNacimiento = this.dtNacimiento.Value;
                nuevoAlu.Telefono = this.txtTelefono.Text;
                nuevoAlu.Legajo = int.Parse(this.txtLegajo.Text);
                nuevoAlu.Direccion= this.txtDireccion.Text;
                nuevoAlu.IDPlan = int.Parse(this.cmbPlan.SelectedValue.ToString());

                if (Modo == ModoForm.Alta)
                {
                    nuevoAlu.State = BusinessEntity.States.New;
                    alu.Save(nuevoAlu);
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoAlu.ID = int.Parse(this.txtID.Text);
                    nuevoAlu.State = BusinessEntity.States.Modified;
                    alu.Save(nuevoAlu);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoAlu.ID = int.Parse(this.txtID.Text);
                nuevoAlu.State = BusinessEntity.States.Deleted;
                alu.Save(nuevoAlu);
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
                    rta = Validaciones.EsFechaNacimientoValida(dtNacimiento.Value);
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
                Notificar("Ficha de usuario vacía",
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
