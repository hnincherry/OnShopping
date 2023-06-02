using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

public partial class User_Product : System.Web.UI.Page
{
    MainDatasetTableAdapters.CategoryTableAdapter CategoryTbl = new MainDatasetTableAdapters.CategoryTableAdapter();
    MainDatasetTableAdapters.ProductTableAdapter ProductTbl = new MainDatasetTableAdapters.ProductTableAdapter();
    DataTable Dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dt = CategoryTbl.Category_Select_By_Product();
            CatNameList.DataSource = Dt;
            CatNameList.DataBind();
            if (Dt.Rows.Count > 0)
            {
                Productlist.DataSource = ProductTbl.Product_Select_By_CatID(Convert.ToInt32(Dt.Rows[0][1].ToString()));
                Productlist.DataBind();
            }
        }   
    }

    protected void CatNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Productlist.DataSource = ProductTbl.Product_Select_By_CatID(Convert.ToInt32(CatNameList.SelectedValue.ToString()));
        Productlist.DataBind();
    }

    protected void Productlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ProductID"] = Productlist.SelectedValue.ToString();
        Response.Redirect("ProductDetail.aspx");
    }
}