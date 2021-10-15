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
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class frmReporteCursos : Form
    {
        public frmReporteCursos()
        {
            InitializeComponent();
        }

        private void frmReporteCursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            CursoLogic ul = new CursoLogic();
            try
            {
                ReportDataSource rds = new ReportDataSource("dsReporteCursos", ul.GetAll());
                this.rvwrCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.ReporteCursos.rdlc";
                this.rvwrCursos.LocalReport.DataSources.Clear();
                this.rvwrCursos.LocalReport.DataSources.Add(rds);
                this.rvwrCursos.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de curso " + Ex, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
