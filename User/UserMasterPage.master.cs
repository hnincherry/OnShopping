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

public partial class User_UserMasterPage : System.Web.UI.MasterPage
{
    MainDatasetTableAdapters.OrderTableAdapter OrderTbl = new MainDatasetTableAdapters.OrderTableAdapter();
    DataTable Dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginCustomer"] != null) {
            Dt = OrderTbl.Order_Select_By_NotiStatus(Convert.ToInt32(Session["LoginCustomer"]));
            if (Dt.Rows.Count > 0)
                Session["NotiStatus"] = "Y";
        }

        if (Session["NotiStatus"] != null) {
            if (Session["NotiStatus"] == "-")
                btnMessage.Visible = false;
            else
                btnMessage.Visible = true;
        }
    }
}
