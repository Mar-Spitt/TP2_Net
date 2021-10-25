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
    public partial class ReporteCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CursoLogic ul = new CursoLogic();
                try
                {
                    ReportDataSource rds = new ReportDataSource("dsReporteCursos", ul.GetAll());
                    this.rvwrCursos.LocalReport.ReportEmbeddedResource = "UI.Web.ReporteCursos.rdlc";
                    this.rvwrCursos.LocalReport.DataSources.Clear();
                    this.rvwrCursos.LocalReport.DataSources.Add(rds);
                    this.rvwrCursos.DataBind();
                }
                catch (Exception Ex)
                {
                    Response.Write("Error al recuperar lista de curso " + Ex);
                }
            }

        }
    }
}