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

public partial class Admin_Product : System.Web.UI.Page
{
    MainDatasetTableAdapters.ProductTableAdapter ProductTbl = new MainDatasetTableAdapters.ProductTableAdapter();
    MainDatasetTableAdapters.CategoryTableAdapter CategoryTbl = new MainDatasetTableAdapters.CategoryTableAdapter();
    DataTable Dt = new DataTable();
    DataTable DtDisplay = new DataTable();
    DataRow Dr;
    int Count;

    protected void Page_Load(object sender, EventArgs e)
    {
        Dt = ProductTbl.GetData();
        DisplayProduct();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void DisplayProduct()
    {
        DtDisplay.Columns.Clear();
        DtDisplay.Rows.Clear();

        DtDisplay.Columns.Add("No");
        DtDisplay.Columns.Add("ProID");
        DtDisplay.Columns.Add("ProName");
        DtDisplay.Columns.Add("CatID");
        DtDisplay.Columns.Add("CatName");
        DtDisplay.Columns.Add("Price");
        DtDisplay.Columns.Add("Quantity");
        DtDisplay.Columns.Add("Image");

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
                Dr[4] = Dt.Rows[i][4];
                Dr[5] = Dt.Rows[i][5];
                Dr[6] = Dt.Rows[i][6];
                Dr[7] = Dt.Rows[i][7];
                DtDisplay.Rows.Add(Dr);
            }
        }
        GridView1.DataSource = DtDisplay;
        GridView1.DataBind();

        txtSearch.Focus();
    }

    protected void DisplayCategory()
    {
        ddlCategoryName.DataTextField = "CatName";
        ddlCategoryName.DataValueField = "CatID";
        ddlCategoryName.DataSource = CategoryTbl.GetData();
        ddlCategoryName.DataBind();
    }

    protected void ClearData()
    {
        txtSearch.Text = "";
        txtProductID.Text = "";
        txtProductName.Text = "";
        ddlCategoryName.SelectedIndex = -1;
        txtPrice.Text = "";
        txtQuantity.Text = "";
        txtImage.Text = "";
    }

    private string ImageLocation(int ProID)
    {
        string filename = FileUploadImage.FileName;
        string FilePath = Server.MapPath("~/Images/ProImage/") + ProID + ".jpg";

        if (System.IO.File.Exists(FilePath))
            System.IO.File.Delete(FilePath);

        if (filename != string.Empty)
        {
            FileUploadImage.SaveAs(FilePath);
            return "~/Images/ProImage/" + ProID + ".jpg";
        }
        else
        {
            return "~/Images/ProImage/Image1.jpg";
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnSave.Text = "Save";
        DisplayCategory();
        MultiView1.ActiveViewIndex = 1;
        ClearData();
        txtProductName.Focus();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtProductID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Update";
            MultiView1.ActiveViewIndex = 0;
        }
        else
        {
            lblError1.Text = "";
            DisplayCategory();
            MultiView1.ActiveViewIndex = 1;
            txtProductName.Focus();
            ddlCategoryName.SelectedValue = btnSave.Text;
            btnSave.Text = "Update";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtProductID.Text.Trim().ToString() == string.Empty)
        {
            lblError1.Text = "Please Choose One Record For Delete";
        }
        else if (Convert.ToInt32(txtQuantity.Text.Trim().ToString()) > 0)
        {
            lblError1.Text = "This Product Have In Stock";
        }
        else
        {
            string ImagePath = Server.MapPath(txtImage.Text);
            if (txtImage.Text.Contains("Image1.jpg") == false)
            {
                if (System.IO.File.Exists(ImagePath))
                    System.IO.File.Delete(ImagePath);

            }
            ProductTbl.Product_Delete(Convert.ToInt32(txtProductID.Text));
            Response.Redirect("Product.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ok;

        if (txtProductName.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Enter Product Name";
            txtProductName.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtPrice.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Enter Price";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (int.TryParse(txtPrice.Text, out ok) == false)
        {
            lblError2.Text = "Price Should Be Number";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (Convert.ToInt32(txtPrice.Text) < 1000 || Convert.ToInt32(txtPrice.Text) > 10000000)
        {
            lblError2.Text = "Price Should Be Between 10,00 And 10,000,000";
            txtPrice.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (txtQuantity.Text.Trim().ToString() == string.Empty)
        {
            lblError2.Text = "Please Enter Quantity";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (int.TryParse(txtQuantity.Text, out ok) == false)
        {
            lblError2.Text = "Quantity Should Be Number";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else if (Convert.ToInt32(txtQuantity.Text) < 0)
        {
            lblError2.Text = "Quantity Should Be Zero And Above";
            txtQuantity.Focus();
            MultiView1.ActiveViewIndex = 1;
        }
        else
        {
            Dt = ProductTbl.Product_Select_By_ProNameCatName(txtProductName.Text, ddlCategoryName.SelectedItem.ToString());
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][1].ToString() != txtProductID.Text)
                {
                    lblError2.Text = "This Product Is Already Exist";
                    MultiView1.ActiveViewIndex = 1;
                    return;
                }
            }
            if (btnSave.Text == "Save")
            {
                ProductTbl.Product_Insert(Convert.ToInt32(ddlCategoryName.SelectedValue), txtProductName.Text, Convert.ToInt32(txtPrice.Text.ToString()), Convert.ToInt32(txtQuantity.Text.ToString()));
                int ProID = Convert.ToInt32(ProductTbl.Product_Select_By_MaxProID().Rows[0][1]);
                //Page.Response.Write("<script>console.log('" + ProID + "');</script>");
                ProductTbl.Product_Insert_Image(ProID, ImageLocation(ProID));
            }
            else if (btnSave.Text == "Update")
            {
                int ProID = Convert.ToInt32(txtProductID.Text);
                string ImagePath = ImageLocation(ProID);
                ProductTbl.Product_Update(Convert.ToInt32(txtProductID.Text), Convert.ToInt32(ddlCategoryName.SelectedValue), txtProductName.Text, Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtQuantity.Text), ImagePath.ToString());
            }
            ClearData();
            Dt = ProductTbl.GetData();
            DisplayProduct();
            MultiView1.ActiveViewIndex = 0;

            Response.Redirect("Product.aspx");
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex = GridView1.SelectedIndex;
        txtProductID.Text = DtDisplay.Rows[RowIndex][1].ToString();
        txtProductName.Text = DtDisplay.Rows[RowIndex][2].ToString();
        btnSave.Text = DtDisplay.Rows[RowIndex][3].ToString();
        txtPrice.Text = DtDisplay.Rows[RowIndex][5].ToString();
        txtQuantity.Text = DtDisplay.Rows[RowIndex][6].ToString();
        txtImage.Text = DtDisplay.Rows[RowIndex][7].ToString();
        GridViewRow Row2 = GridView1.Rows[RowIndex];
        CheckBox chkSelect2 = (CheckBox)Row2.FindControl("chkSelect");
        chkSelect2.Checked = true;
    }

    protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        txtSearch.Focus();
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 0)
            Dt = ProductTbl.Product_Select_By_SearchProName(txtSearch.Text);
        else if (ddlSearchType.SelectedIndex == 1)
            Dt = ProductTbl.Product_Select_By_SearchCatName(txtSearch.Text);
        else if (ddlSearchType.SelectedIndex == 2)
            Dt = ProductTbl.Product_Select_By_SearchPrice(txtSearch.Text);
        else if (ddlSearchType.SelectedIndex == 3)
            Dt = ProductTbl.Product_Select_By_SearchQuantity(txtSearch.Text);

        DisplayProduct();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text.Trim().ToString() != string.Empty)
        {
            if (ddlSearchType.SelectedIndex == 0)
                Dt = ProductTbl.Product_Select_By_SearchProName(txtSearch.Text);
            else if (ddlSearchType.SelectedIndex == 1)
                Dt = ProductTbl.Product_Select_By_SearchCatName(txtSearch.Text);
            else if (ddlSearchType.SelectedIndex == 2)
                Dt = ProductTbl.Product_Select_By_SearchPrice(txtSearch.Text);
            else if (ddlSearchType.SelectedIndex == 3)
                Dt = ProductTbl.Product_Select_By_SearchQuantity(txtSearch.Text);
        }
        else
        {
            Dt = ProductTbl.GetData();
        }
        Session["ReportDt"] = Dt;
        Session["ReportName"] = "crptProduct.rpt";
        Response.Redirect("Report.aspx"); 
    }
}