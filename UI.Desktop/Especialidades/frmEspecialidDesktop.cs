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
    public partial class frmEspecialidDesktop : AplicationForm
    {
        public frmEspecialidDesktop()
        {
            InitializeComponent();
        }

        public frmEspecialidDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Especialidad EspecialidadActual { get; set; }
        private void EnableForm(bool enable)
        {
            this.txtId.Enabled = enable;
            this.txtEspecialidad.Enabled = enable;
        }

        public frmEspecialidDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Baja)
            {
                EnableForm(false);
            }
            EspecialidadLogic esp = new EspecialidadLogic();
            try
            {
                EspecialidadActual = esp.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de especialidades" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.EspecialidadActual.ID.ToString();
            this.txtEspecialidad.Text = this.EspecialidadActual.Descripcion;
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
            EspecialidadLogic esp = new EspecialidadLogic();
            Especialidad nuevoEsp = new Especialidad();
            EspecialidadActual = nuevoEsp;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoEsp.Descripcion = this.txtEspecialidad.Text;

                if (Modo == ModoForm.Alta)
                {
                    nuevoEsp.State = BusinessEntity.States.New;
                    esp.Save(nuevoEsp);
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoEsp.ID = int.Parse(this.txtId.Text);
                    nuevoEsp.State = BusinessEntity.States.Modified;
                    esp.Save(nuevoEsp);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoEsp.ID = int.Parse(this.txtId.Text);
                nuevoEsp.State = BusinessEntity.States.Deleted;
                esp.Save(nuevoEsp);
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
            if (this.txtEspecialidad.Text != String.Empty)
            {
                rta = true;
            }
            else
            {
                Notificar("Descripción de especialidad vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
            return rta;
        }
    }
}
