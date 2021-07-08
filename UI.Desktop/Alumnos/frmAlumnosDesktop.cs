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
        }
        public frmAlumnosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public Persona AlumnoActual { get; set; }
        public frmAlumnosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
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
            this.txtIDPlan.Text = this.AlumnoActual.IDPlan.ToString();
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
                // TODO: SI ingresea un valor muy alto en legajo (manejador de exepciones
                // TODO: Valide con el id_pan si exite (manejador de excepciones)
                nuevoAlu.Legajo = int.Parse(this.txtLegajo.Text);
                nuevoAlu.Direccion= this.txtDireccion.Text;
                nuevoAlu.IDPlan = int.Parse(this.txtIDPlan.Text);

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
                && txtEmail.Text != String.Empty && txtIDPlan.Text != String.Empty
                && txtLegajo.Text != String.Empty)
            {
                rta = validarEmail(txtEmail.Text);
                if (!rta)
                {
                    Notificar("Email inválido",
                              "Revise su correo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
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
        public static bool validarEmail(string email)
        {
            String expresion;
            bool rta2 = false;
            expresion = @"\A(\w+.?\w*@\w+.)(com)\Z";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    rta2 = true;
                }
            }
            return rta2;
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
