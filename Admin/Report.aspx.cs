using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

public partial class Admin_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = "sa";
        string password = "kmd";
        if (Session["ReportDt"] != null && Session["ReportName"] == "crptAdmin.rpt")
        {
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath(Session["ReportName"].ToString()));
            report.SetDataSource((DataTable)Session["ReportDt"]);
            report.SetDatabaseLogon(username, password);
            
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer2.Visible = false;
            CrystalReportViewer3.Visible = false;
            //CrystalReportViewer4.Visible = false;
        }

        else if (Session["ReportDt"] != null && Session["ReportName"] == "crptCategory.rpt")
        {

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath(Session["ReportName"].ToString()));
            report.SetDataSource((DataTable)Session["ReportDt"]);
            report.SetDatabaseLogon(username, password);
            
            CrystalReportViewer2.DataBind();
            CrystalReportViewer2.ReportSource = report;
            CrystalReportViewer1.Visible = false;
            CrystalReportViewer3.Visible = false;
            //CrystalReportViewer4.Visible = false;
        }

        else if (Session["ReportDt"] != null && Session["ReportName"] == "crptProduct.rpt")
        {

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath(Session["ReportName"].ToString()));
            report.SetDataSource((DataTable)Session["ReportDt"]);
            report.SetDatabaseLogon(username, password);

            CrystalReportViewer3.DataBind();
            CrystalReportViewer3.ReportSource = report;
            CrystalReportViewer1.Visible = false;
            CrystalReportViewer2.Visible = false;
            //CrystalReportViewer4.Visible = false;
        }
    }
}