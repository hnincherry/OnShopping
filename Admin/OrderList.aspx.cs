using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;

public partial class Admin_OrderList : System.Web.UI.Page
{
    MainDatasetTableAdapters.Admin_OrderTableAdapter Admin_Order = new MainDatasetTableAdapters.Admin_OrderTableAdapter();
    MainDatasetTableAdapters.Admin_OrderDetailTableAdapter Admin_OrderDetail = new MainDatasetTableAdapters.Admin_OrderDetailTableAdapter();
    MainDatasetTableAdapters.Admin_Order_ReportTableAdapter Admin_OrderReport = new MainDatasetTableAdapters.Admin_Order_ReportTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;
    protected void DisplayAdminOrder()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();

        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("OrderID");
        DtDisplay.Columns.Add("OrderDate");
        DtDisplay.Columns.Add("CustName");
        DtDisplay.Columns.Add("ShippingAdd");
        DtDisplay.Columns.Add("Total");
        DtDisplay.Columns.Add("DeliverStatus");

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
                Dr[3] = Dt.Rows[i][4];
                Dr[4] = Dt.Rows[i][5];
                Dr[5] = Dt.Rows[i][6];
                Dr[6] = Dt.Rows[i][7];
                DtDisplay.Rows.Add(Dr);
            }
        }
        DataList1.DataSource = DtDisplay;
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = Admin_Order.GetData();
        DisplayAdminOrder();
    }
    protected void DataList1_PreRender(object sender, EventArgs e)
    {
        for (int i = 0; i < Count; i++)
        {
            Dr = DtDisplay.Rows[i];
            DataListItem Row = DataList1.Items[i];
            GridView GV = (GridView)Row.FindControl("GridView1");
            Dt = Admin_OrderDetail.Admin_OrderDetail_Select_By_OrderID(Convert.ToInt32(Dr[1]));
            GV.DataSource = Dt;
            GV.DataBind();

        }
    }
    protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        {
            txtOrderDate.Visible = true;
            txtOrderDate.Text = "";
            txtOrderDate.Focus();
            txtSearchData.Visible = false;
        }
        else
        {
            txtOrderDate.Visible = false;
            txtSearchData.Visible = true;
            txtSearchData.Text = "";
            txtSearchData.Focus();
        }
    }
    protected void txtOrderDate_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        {
            if (txtOrderDate.Text.Trim().ToString() == string.Empty)
                Dt = Admin_Order.GetData();
            else
                Dt = Admin_Order.Admin_Order_Select_By_OrderDate(txtOrderDate.Text.Trim().ToString());

            DisplayAdminOrder();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
        {
            if (txtOrderDate.Text.Trim().ToString() == string.Empty)
                Dt = Admin_OrderReport.GetData();
            else
            {
                if (ddlSearchType.SelectedIndex == 0)
                {
                    Dt = Admin_OrderReport.Admin_Order_Report_Select_By_OrderDate(txtOrderDate.Text);

                }
            }
        }
        if (ddlSearchType.SelectedIndex == 1)
        {
            Dt = Admin_OrderReport.Admin_Order_Report_Select_By_CustomerName(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            Dt = Admin_OrderReport.Admin_Order_Report_Select_By_ShippingAdd(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            Dt = Admin_OrderReport.Admin_Order_Report_Select_By_Total(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 4)
        {
            Dt = Admin_OrderReport.Admin_Order_Report_Select_By_DeliverStatus(txtSearchData.Text);
        }

        Session["ReportDt"] = Dt;
        Session["ReportName"] = "crptOrder.rpt";
        Response.Redirect("Report.aspx");

    }
    protected void txtSearchData_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 1)
        {
            Dt = Admin_Order.Admin_Order_Select_By_CustName(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            Dt = Admin_Order.Admin_Order_Select_By_ShippingAdd(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            Dt = Admin_Order.Admin_Order_Select_By_Total(txtSearchData.Text);
        }
        else if (ddlSearchType.SelectedIndex == 4)
        {
            Dt = Admin_Order.Admin_Order_Select_By_DeliverStatus(txtSearchData.Text);
        }
        DisplayAdminOrder();
    }
}