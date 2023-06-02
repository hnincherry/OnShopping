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

public partial class User_ProductDetail : System.Web.UI.Page
{
    MainDatasetTableAdapters.ProductTableAdapter ProductTbl = new MainDatasetTableAdapters.ProductTableAdapter();
    DataTable Dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = ProductTbl.Product_Select_By_ProID(Convert.ToInt32(Session["ProductID"]));
        if (Dt.Rows.Count > 0)
        {
            foreach (DataRow Dr in Dt.Rows)
            {
                imgProduct.ImageUrl = Dr["Image"].ToString();
                lblCategoryName.Text = Dr["CatName"].ToString();
                lblPrice.Text = Dr["Price"].ToString();
                lblProductName.Text = Dr["ProName"].ToString();
            }
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Product.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable Tbl = new DataTable();
        DataRow TblDr;

        Tbl.Columns.Add("ProID");
        Tbl.Columns.Add("Qty");
        Tbl.Rows.Clear();

        if (Session["TempTbl"] != null)
        {
            Tbl = (DataTable)Session["TempTbl"];
            DataRow[] DrArray = Tbl.Select("ProID='" + Session["ProductID"] + "'");
            foreach (DataRow Dr in DrArray)
            {
                Dr[1] = Convert.ToInt32(Dr[1]) + 1;
                Tbl.AcceptChanges();
                Session["TempTbl"] = Tbl;
                Response.Redirect("ShoppingCard.aspx");
                return;
            }
        }

        TblDr = Tbl.NewRow();
        TblDr[0] = Session["ProductID"];
        TblDr[1] = 1;
        Tbl.Rows.Add(TblDr);

        Session["TempTbl"] = Tbl;
        Response.Redirect("ShoppingCard.aspx");
    }
}