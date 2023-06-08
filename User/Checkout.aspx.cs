using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

public partial class User_CheckOut : System.Web.UI.Page
{
    MainDatasetTableAdapters.ProductTableAdapter ProductTbl = new MainDatasetTableAdapters.ProductTableAdapter();
    MainDatasetTableAdapters.CustomerTableAdapter CustomerTbl = new MainDatasetTableAdapters.CustomerTableAdapter();
    MainDatasetTableAdapters.OrderTableAdapter OrderTbl = new MainDatasetTableAdapters.OrderTableAdapter();
    MainDatasetTableAdapters.OrderDetailTableAdapter OrderDetailTbl = new MainDatasetTableAdapters.OrderDetailTableAdapter();
    DataTable Dt1 = new DataTable();
    DataTable Dt2 = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;
    int Qty, Price, Total;

    string TodayDate;
    String Day, Month, Year;
    protected void SelectTempTbl()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();
        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("ProID");
        DtDisplay.Columns.Add("ProName");
        DtDisplay.Columns.Add("CatName");
        DtDisplay.Columns.Add("Price");
        DtDisplay.Columns.Add("Qty");

        Count = Dt1.Rows.Count;

        for (int i = 0; i < Count; i++)
        {
            int ProID = Convert.ToInt32(Dt1.Rows[i][0].ToString());
            Dt2 = ProductTbl.Product_Select_By_ProID(ProID);
            Dr = DtDisplay.NewRow();
            Dr[0] = Dt2.Rows[0][0];
            Dr[1] = Dt2.Rows[0][1];
            Dr[2] = Dt2.Rows[0][2];
            Dr[3] = Dt2.Rows[0][4];
            Dr[4] = Dt2.Rows[0][5];
            Dr[5] = Dt1.Rows[i][1];
            DtDisplay.Rows.Add(Dr);
            GridView1.DataSource = DtDisplay;
            GridView1.DataBind();
        }
    }
    protected void TotalNDay()
    {
        foreach (GridViewRow Row in GridView1.Rows)
        {
            Price = Convert.ToInt32(Row.Cells[4].Text.ToString());
            Qty = Convert.ToInt32(Row.Cells[5].Text.ToString());

            Total += Convert.ToInt32(Qty * Price);
        }

        txtTotal.Text = Total.ToString();

        Day = string.Format("{0:D2}", DateTime.Now.Day);
        Month = string.Format("{0:D2}", DateTime.Now.Month);
        Year = DateTime.Today.Year.ToString();

        TodayDate = Day + "/" + Month + "/" + Year;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Dt1 = (DataTable)Session["TempTbl"];

        if (!IsPostBack)
        {
            if (Session["TempTbl"] == null)
            {
                Response.Redirect("Product.aspx");
            }
            else
            {
                if (Dt1.Rows.Count <= 0)
                    Response.Redirect("Product.aspx");
                else
                    SelectTempTbl();
            }
            txtLoad.Text = "Load";
        }

        TotalNDay();
        if (Session["LogInCustomer"] != null)
        {
            Dt2 = CustomerTbl.Customer_Select_By_CustID(Convert.ToInt32(Session["LogInCustomer"].ToString()));

            foreach (DataRow Dr in Dt2.Rows)
            {
                txtCustomerName.Text = Dr["CustName"].ToString();
                txtCardType.Text = Dr["CType"].ToString();
                txtAccountNo.Text = Dr["AccNo"].ToString();
                //txtShipAdd.Text = Dr["Address"].ToString();

            }
            txtShipAdd.Focus();

        }
    }
    protected void btnCancleShop_Click(object sender, EventArgs e)
    {
        DataTable Dt = (DataTable)Session["TempTbl"];
        Dt.Rows.Clear();

        Response.Redirect("Product.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (Session["LogInCustomer"] == null)
        {
            Response.Redirect("CustomerLogIn.aspx");
        }
        else if (txtShipAdd.Text.ToString() == "")
        {
            lblError.Text = "Please Type Shipped Address";
        }
        else
        {

            OrderTbl.Order_Insert(TodayDate.ToString(), Convert.ToInt32(Session["LogInCustomer"].ToString()), txtShipAdd.Text, Convert.ToInt32(txtTotal.Text), "Order...");

            int RowIndex = OrderTbl.GetData().Rows.Count;
            int OrderID = Convert.ToInt32(OrderTbl.GetData().Rows[RowIndex - 1][0].ToString());

            int Index = 0;
            foreach (GridViewRow Row in GridView1.Rows)
            {
                OrderDetailTbl.Order_Detail_Insert(OrderID, Convert.ToInt32(Dt1.Rows[Index][0].ToString()), Convert.ToInt32(Row.Cells[4].Text.ToString()), Convert.ToInt32(Row.Cells[5].Text.ToString()));
                Index = Index + 1;
            }
            DataTable Dt = (DataTable)Session["TempTbl"];
            Dt.Rows.Clear();
            Response.Redirect("Product.aspx");
        }
    }
}