using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;

public partial class User_CustomerLogin : System.Web.UI.Page
{
    MainDatasetTableAdapters.OrderTableAdapter OrderTbl = new MainDatasetTableAdapters.OrderTableAdapter();
    MainDatasetTableAdapters.CustomerTableAdapter CustomerTbl = new MainDatasetTableAdapters.CustomerTableAdapter();
    DataTable Dt = new DataTable();
    int Count;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Email";
            txtEmail.Focus();
        }
        else if (txtEmail.Text.Contains(".") == false || txtEmail.Text.Contains("@") == false)
        {
            lblError.Text = "Please Type Correct Email Format";
            txtEmail.Focus();
        }
        else if (txtPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Password";
            txtPassword.Focus();
        }
        else
        {
            Dt = CustomerTbl.Customer_Select_For_Login(txtEmail.Text, txtPassword.Text);
            if (Dt.Rows.Count > 0)
            {
                Session["LogInCustomer"] = Dt.Rows[0][1].ToString();

                Dt = OrderTbl.Order_Select_By_NotiStatus(Convert.ToInt32(Session["LogInCustomer"]));
                Count = Dt.Rows.Count;
                if (Count > 0)
                {
                    Session["NotiStatus"] = "Y";
                }
                else
                {
                    Session["NotiStatus"] = "-";
                }

                if (Session["URL"] != null)
                {
                    Response.Redirect(Session["URL"].ToString());
                }
                else
                {
                    Response.Redirect("Product.aspx");
                }
            }
            else
            {
                lblError.Text = "Please Check Email And Password";
            }
        }
    }
}