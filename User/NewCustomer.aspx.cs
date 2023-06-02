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

public partial class User_NewCustomer : System.Web.UI.Page
{
    MainDatasetTableAdapters.CustomerTableAdapter CustomerTbl = new MainDatasetTableAdapters.CustomerTableAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ClearData()
    {
        txtAddress.Text = "";
        txtCustomerName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        ddlCType.SelectedIndex = 0;
        txtANo.Text = "";
        txtCustomerName.Focus();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCustomerName.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Customer Name";
            txtCustomerName.Focus();
        }
        else if (txtAddress.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Address";
            txtAddress.Focus();
        }
        else if (txtPhone.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Phone";
            txtPhone.Focus();
        }
        else if (txtEmail.Text.Trim().ToString() == string.Empty)
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
        else if (txtConfirmPassword.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Confirm Password";
            txtConfirmPassword.Focus();
        }
        else if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblError.Text = "Password And Confirm Password Should Be Match";
            txtPassword.Focus();
        }
        else if (txtANo.Text.Trim().ToString() == string.Empty)
        {
            lblError.Text = "Please Enter Account No";
            txtANo.Focus();
        }
        else if (CustomerTbl.Customer_Select_By_Email(txtEmail.Text).Rows.Count > 0)
        {
            lblError.Text = "This Customer Email Is Already Exist";
            txtEmail.Focus();
        }
        else
        {
            CustomerTbl.Customer_Insert(txtCustomerName.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, txtPassword.Text, ddlCType.SelectedItem.ToString(), txtANo.Text);
            lblError.Text = "Save Successfully One Record";
            ClearData();
        }
    }
}