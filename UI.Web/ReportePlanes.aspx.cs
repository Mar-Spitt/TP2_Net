using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class ReportePlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlanLogic pl = new PlanLogic();
                try
                {
                    ReportDataSource rds = new ReportDataSource("dsReportePlanes", pl.GetAll());
                    this.rvwrPlanes.LocalReport.ReportEmbeddedResource = "UI.Web.ReportePlanes.rdlc";
                    this.rvwrPlanes.LocalReport.DataSources.Clear();
                    this.rvwrPlanes.LocalReport.DataSources.Add(rds);
                    this.rvwrPlanes.DataBind();
                }
                catch (Exception Ex)
                {
                    Response.Write("Error al recuperar lista de curso " + Ex);
                }
            }

        }
    }
}