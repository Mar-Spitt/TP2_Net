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
using System.Text.RegularExpressions;


namespace UI.Desktop.Planes_y_Materias
{
    public partial class frmMateriasDesktop : AplicationForm
    {
        public frmMateriasDesktop()
        {
            InitializeComponent();

            PlanLogic ml = new PlanLogic();
            cmbPlan.DataSource = ml.GetAll();
            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";
        }

        public frmMateriasDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Materia MateriaActual { get; set; }

        public frmMateriasDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ma = new MateriaLogic();
            try
            {
                MateriaActual = ma.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de materias" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cmbPlan.SelectedValue = this.MateriaActual.IDPlan;
            
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
            MateriaLogic ma = new MateriaLogic();
            Materia nuevoMat = new Materia();
            MateriaActual = nuevoMat;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                nuevoMat.Descripcion = this.txtDescripcion.Text;
                nuevoMat.HSSemanales = int.Parse(this.txtHsSemanales.Text);
                nuevoMat.HSTotales = int.Parse(this.txtHsTotales.Text);
                nuevoMat.IDPlan = int.Parse(this.cmbPlan.SelectedValue.ToString());

                if (Modo == ModoForm.Alta)
                {
                    nuevoMat.State = BusinessEntity.States.New;
                    ma.Save(nuevoMat);
                }

                if (Modo == ModoForm.Modificacion)
                {
                    nuevoMat.ID = int.Parse(this.txtID.Text);
                    nuevoMat.State = BusinessEntity.States.Modified;
                    ma.Save(nuevoMat);
                }
            }

            if (Modo == ModoForm.Baja)
            {
                nuevoMat.ID = int.Parse(this.txtID.Text);
                nuevoMat.State = BusinessEntity.States.Deleted;
                ma.Save(nuevoMat);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
        }

        public override bool Validar()
        {
            bool rta = false;
            if (this.txtDescripcion.Text != String.Empty && this.cmbPlan.SelectedValue.ToString() != String.Empty
                && this.txtHsSemanales.Text != String.Empty && this.txtHsTotales.Text !=String.Empty)
            {
                rta = true;
            }
            else
            {
                Notificar("Ficha de materia vacía",
                          "No puede haber campos vacíos",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
            return rta;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        //private void frmMateriasDesktop_Load(object sender, EventArgs e)
        //{
        //    // TODO: esta línea de código carga datos en la tabla 'tP2_AcademiaDataSet.especialidades' Puede moverla o quitarla según sea necesario.
        //    this.planesTableAdapter.Fill(this.tP2_AcademiaDataSet.planes);

        //}

    }
}
