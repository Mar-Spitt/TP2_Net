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
    public partial class frmReportePlanes : Form
    {
        public frmReportePlanes()
        {
            InitializeComponent();
        }

        private void frmReportePlanes_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                ReportDataSource rds = new ReportDataSource("dsReportePlanes", pl.GetAll());
                this.rvwrPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.ReportePlanes.rdlc";
                this.rvwrPlanes.LocalReport.DataSources.Clear();
                this.rvwrPlanes.LocalReport.DataSources.Add(rds);
                this.rvwrPlanes.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de plan " + Ex, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
