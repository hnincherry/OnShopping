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

public partial class Admin_Category : System.Web.UI.Page
{
    MainDatasetTableAdapters.CategoryTableAdapter CategoryTbl = new MainDatasetTableAdapters.CategoryTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = CategoryTbl.GetData();
        DisplayCategory();

        MultiView1.ActiveViewIndex = 0;
    }

    protected void DisplayCategory()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();

        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("CatID");
        DtDisplay.Columns.Add("CatName");

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
        txtCatID.Text = "";
        txtCategoryName.Text = "";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        ClearData();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtCatID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Update";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            lblError1.Text = "";
            DisplayCategory();
            MultiView1.ActiveViewIndex = 1;
            txtCategoryName.Focus();
            btnSave.Text = "Update";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtCatID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Delete";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            CategoryTbl.Category_Delete(Convert.ToInt32(txtCatID.Text));
            Response.Redirect("Category.aspx");
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim().ToString() == string.Empty)
            Dt = CategoryTbl.GetData();
        else
            Dt = CategoryTbl.Category_Select_By_Search_CatName(txtSearch.Text.Trim().ToString());
            Response.Write("Row => " + Dt.Rows.Count);

            Session["ReportDt"] = Dt;
            Session["ReportName"] = "crptCategory.rpt";
            Response.Redirect("Report.aspx");
    }
    protected void txtSearch_Changed(object sender, EventArgs e)
    {
        Dt = CategoryTbl.Category_Select_By_Search_CatName(txtSearch.Text);
        DisplayCategory();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCategoryName.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Type Category Name";
            txtCategoryName.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Dt = CategoryTbl.Category_Select_By_CatName(txtCategoryName.Text.Trim().ToString());

            if (Dt.Rows.Count > 0)
            {
                lblError2.Text = "This Category is Already Exist";
                MultiView1.ActiveViewIndex = 1;
                return;
            }
            if (btnSave.Text == "Save")
            {
                CategoryTbl.Category_Insert(txtCategoryName.Text.Trim());
            }
            else if (btnSave.Text == "Update")
            {
                CategoryTbl.Category_Update(Convert.ToInt32(txtCatID.Text), txtCategoryName.Text.Trim());
            }
            ClearData();
            Dt = CategoryTbl.GetData();
            DisplayCategory();
            MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
        txtCatID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        txtCategoryName.Text = DtDisplay.Rows[RowIndex][2].ToString();
        GridViewRow Row = GridView1.Rows[RowIndex];
        CheckBox chkSelect = (CheckBox)Row.FindControl("chkSelect");
        chkSelect.Checked = true;
    }
}