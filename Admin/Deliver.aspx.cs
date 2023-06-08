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

public partial class Admin_Deliver : System.Web.UI.Page
{
    MainDatasetTableAdapters.Admin_OrderTableAdapter Admin_Order = new MainDatasetTableAdapters.Admin_OrderTableAdapter();
    MainDatasetTableAdapters.OrderTableAdapter OrderTbl = new MainDatasetTableAdapters.OrderTableAdapter();
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
        GridView1.DataSource = DtDisplay;
        GridView1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = Admin_Order.Admin_Order_Select_By_Deliver();
        DisplayAdminOrder();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
        txtOrderID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        GridViewRow Row = GridView1.Rows[RowIndex];
        CheckBox chkSelect = (CheckBox)Row.FindControl("chkSelect");
        chkSelect.Checked = true;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string DelvierStatus = "";
        int OrderID = 0;

        if (txtOrderID.Text.ToString() == string.Empty)
            lblError.Text = "Please Select OrderID";
        else
        {
            OrderID = Convert.ToInt32(txtOrderID.Text);
            if (rdoCCE.Checked == false && rdoDel.Checked == false && rdoNEQ.Checked == false)
                lblError.Text = "Please Choose Deliver Status";
            else
            {
                if (rdoCCE.Checked == true)
                    DelvierStatus = "Credit Card Error";
                else if (rdoDel.Checked == true)
                    DelvierStatus = "Deliver";
                else if (rdoNEQ.Checked == true)
                    DelvierStatus = "Not Enought Qty";

                Admin_Order.Admin_Order_Update(OrderID, DelvierStatus);
                OrderTbl.Order_NotiStatus_Update(Convert.ToInt32(OrderID), "Y");
                Response.Redirect("Deliver.aspx");
            }
        }
    }
}