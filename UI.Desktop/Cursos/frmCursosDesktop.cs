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
    public partial class frmCursosDesktop : AplicationForm
    {
        public frmCursosDesktop()
        {
            InitializeComponent();
            MateriaLogic mat = new MateriaLogic();
            cmbMateria.DataSource = mat.GetAll();
            cmbMateria.ValueMember = "ID";
            cmbMateria.DisplayMember = "Descripcion";

            ComisionLogic com = new ComisionLogic();
            cmbComision.DataSource = com.GetAll();
            cmbComision.ValueMember = "ID";
            cmbComision.DisplayMember = "Descripcion";
            
        }

        public frmCursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Curso CursoActual { get; set; }

        public frmCursosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic cur = new CursoLogic();
            try
            {
                CursoActual = cur.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception Ex)
            {
                Notificar("Error", "Error al recuperar lista de cursos" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.CursoActual.ID.ToString();
            this.cmbMateria.SelectedValue = this.CursoActual.IDMateria;
            this.cmbComision.SelectedValue = this.CursoActual.IDComision;
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;

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
                CursoLogic cur = new CursoLogic();
                Curso nuevoCurso = new Curso();
                CursoActual = nuevoCurso;

                if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
                {
                    nuevoCurso.IDMateria = int.Parse(this.cmbMateria.SelectedValue.ToString());
                    nuevoCurso.IDComision = int.Parse(this.cmbComision.SelectedValue.ToString());
                    nuevoCurso.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                    nuevoCurso.Cupo = int.Parse(this.txtCupo.Text);
                    nuevoCurso.Descripcion = this.txtDescripcion.Text;

                    if (Modo == ModoForm.Alta)
                    {
                        nuevoCurso.State = BusinessEntity.States.New;
                        cur.Save(nuevoCurso);
                    }

                    if (Modo == ModoForm.Modificacion)
                    {
                        nuevoCurso.ID = int.Parse(this.txtId.Text);
                        nuevoCurso.State = BusinessEntity.States.Modified;
                        cur.Save(nuevoCurso);
                    }
                }

                if (Modo == ModoForm.Baja)
                {
                    nuevoCurso.ID = int.Parse(this.txtId.Text);
                    nuevoCurso.State = BusinessEntity.States.Deleted;
                    cur.Save(nuevoCurso);
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
            if (this.cmbMateria.SelectedValue.ToString() != String.Empty && this.cmbComision.SelectedValue.ToString() != String.Empty && this.txtAnioCalendario.Text != String.Empty && this.txtCupo.Text != String.Empty && this.txtDescripcion.Text != String.Empty)
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

    }
}
