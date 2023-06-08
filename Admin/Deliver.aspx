<%@ Page Title="Administrator" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Deliver.aspx.cs" Inherits="Admin_Deliver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
   <tr>
    <td>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </td>
   </tr>
  <tr>
    <td>
    <asp:TextBox ID="txtOrderID" runat="server" Visible="False"></asp:TextBox>
        <asp:RadioButton ID="rdoDel" runat="server" Text="Deliver" GroupName="OrderStatus" />
        <asp:RadioButton ID="rdoCCE" runat="server" GroupName="OrderStatus" Text="Credit Card Error" />
        <asp:RadioButton ID="rdoNEQ" runat="server" Text="Not Enough Qty" GroupName="OrderStatus" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="button" 
            onclick="btnUpdate_Click" />
    </td>
  </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" CellPadding="5" 
                CellSpacing="1" Width="900px" AutoGenerateColumns="False" 
                DataKeyNames="OrderID" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="No" />
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" Visible="False" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                    <asp:BoundField DataField="CustName" HeaderText="Customer Name"/>
                    <asp:BoundField DataField="ShippingAdd" HeaderText="Shipp Address" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="DeliverStatus" HeaderText="DeliverStatus" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                          <asp:LinkButton ID="btnEdit" runat="server" CommandName="Select">
                          <asp:CheckBox ID="chkSelect" runat="server" />
                          </asp:LinkButton>
                       </ItemTemplate>
                    </asp:TemplateField> 
                </Columns>
            </asp:GridView> 
        </td>
    </tr>
</table> 
</asp:Content>

