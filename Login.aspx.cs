using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
using CrystalDecisions.Web;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    MainDatasetTableAdapters.AdminTableAdapter AdminTbl = new MainDatasetTableAdapters.AdminTableAdapter();
    DataTable Dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {        
        if (txtAdminName.Text.Trim() == string.Empty) {
            lblError.Text = "Please Type AdminName";
            txtAdminName.Focus();
        }
        else if (txtPassword.Text.Trim() == string.Empty)
        {
            lblError.Text = "Please Type Password";
            txtPassword.Focus();
        }
        else {
            Dt = AdminTbl.Admin_Select_By_AdminNamePassword(txtAdminName.Text, txtPassword.Text);
            if (Dt.Rows.Count > 0)
            {
                Session["AdminLogin"] = Dt.Rows[0][1];
                Response.Redirect("/Admin.aspx");
                Response.Write("Correct");
            }
            else {
                lblError.Text = "Please Retype AdminName And Password";
            }
        }
    }
}