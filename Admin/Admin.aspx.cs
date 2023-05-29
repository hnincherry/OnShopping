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

public partial class Admin_Admin : System.Web.UI.Page
{
    MainDatasetTableAdapters.AdminTableAdapter AdminTbl = new MainDatasetTableAdapters.AdminTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = AdminTbl.GetData();
        DisplayAdmin();

        MultiView1.ActiveViewIndex = 0;
    }

    protected void DisplayAdmin()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();

        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("AdminID");
        DtDisplay.Columns.Add("AdminName");
        DtDisplay.Columns.Add("Password");

        Dr = DtDisplay.NewRow();
        DtDisplay.Rows.Add(Dr);

        Count = Dt.Rows.Count;
        if (Count > 0)
        {
            DtDisplay.Rows.Clear();

            for (int i = 0; i < Count; i++)
            {
                Dr = DtDisplay.NewRow();
                Dr[0] = Dt.Rows[i][0];
                Dr[1] = Dt.Rows[i][1];
                Dr[2] = Dt.Rows[i][2];
                Dr[3] = Dt.Rows[i][3];
                DtDisplay.Rows.Add(Dr);
            }
        }
        GridView1.DataSource = DtDisplay;
        GridView1.DataBind();
        txtSearch.Focus();
    }

    protected void ClearData()
    {
        lblError1.Text = "";
        lblError2.Text = "";
        txtAdminID.Text = "";
        txtAdminName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        ClearData();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAdminName.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Type Admin Name";
            txtAdminName.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Type Password";
            txtPassword.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtConfirmPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Type Confirm Password";
            txtConfirmPassword.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
        {
            lblError2.Text = "Password and Confirm Password Should Be Match";
            txtPassword.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Dt = AdminTbl.Admin_Select_By_AdminNamePassword(txtAdminName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString());

            if (Dt.Rows.Count > 0)
            {
                lblError2.Text = "The Admin is Already Exist";
                MultiView1.ActiveViewIndex = 1;
                return;
            }
            if (btnSave.Text == "Save")
            {
                AdminTbl.Admin_Insert(txtAdminName.Text.Trim(), txtPassword.Text.Trim());
            }
            else if (btnSave.Text == "Update")
            {
                AdminTbl.Admin_Update(Convert.ToInt32(txtAdminID.Text), txtAdminName.Text.Trim(), txtPassword.Text.Trim());
            }
            ClearData();
            Dt = AdminTbl.GetData();
            DisplayAdmin();
            MultiView1.ActiveViewIndex = 0;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
        txtAdminID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        txtAdminName.Text = DtDisplay.Rows[RowIndex][2].ToString();
        GridViewRow Row = GridView1.Rows[RowIndex];
        CheckBox chkSelect = (CheckBox)Row.FindControl("chkSelect");
        chkSelect.Checked = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtAdminID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Update";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            lblError1.Text = "";
            DisplayAdmin();
            MultiView1.ActiveViewIndex = 1;
            txtAdminName.Focus();
            btnSave.Text = "Update";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtAdminID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Delete";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            AdminTbl.Admin_Delete(Convert.ToInt32(txtAdminID.Text));
            Response.Redirect("Admin.aspx");
        }
    }

    protected void txtSearch_Changed(object sender, EventArgs e)
    {
        Dt = AdminTbl.Admin_Select_By_SearchAdminName(txtSearch.Text);
        DisplayAdmin();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim().ToString() == string.Empty)
            Dt = AdminTbl.GetData();
        else
            Dt = AdminTbl.Admin_Select_By_SearchAdminName(txtSearch.Text.Trim().ToString());
            Session["ReportDt"] = Dt;
            Session["ReportName"] = "crptAdmin.rpt";
            Response.Redirect("Report.aspx");
    }
}