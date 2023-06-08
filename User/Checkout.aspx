<%@ Page Title="ABC Computer Sales Center" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="User_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table width="1000" style="color: #000000; border: 1px solid #000000">
        <tr>
            <th colspan="3" class="tablehead">Check Out
                <asp:TextBox ID="txtLoad" runat="server" Visible="False"></asp:TextBox>
            </th>
        </tr>
        <tr>
            <td colspan="3" align="right">
            <div>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>
            </div>
            </td>
        </tr>
        <tr>
            <td rowspan="5">
                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False" CellPadding="5" CellSpacing="1" 
                    DataKeyNames="ProID" Width="550px">
                    <Columns>
                    <asp:BoundField DataField="No" HeaderText="No"></asp:BoundField>
                    <asp:BoundField DataField="ProID" HeaderText="ProID" Visible="False" />
                    <asp:BoundField DataField="ProName" HeaderText="Product Name" />
                    <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty"/>
                    </Columns>
                </asp:GridView>
                <div>
                    <p></p>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Total:<asp:TextBox ID="txtTotal" runat="server" Enabled="False"></asp:TextBox>
                </div>
            </td>
            
            <td class="col">Customer Name:</td>
            <td><asp:TextBox ID="txtCustomerName" runat="server" Enabled="False" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="col">Card Type:</td>
            <td>
                <asp:TextBox ID="txtCardType" runat="server" Enabled="False" Width="200px"></asp:TextBox>
            </td>  
        </tr>
        <tr>
            <td class="col">Account No:</td>
            <td>
                <asp:TextBox ID="txtAccountNo" runat="server" Width="200" Enabled="False"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="col">Shipped Address:</td>
            <td>
                <asp:TextBox ID="txtShipAdd" runat="server" Rows="5" TextMode="MultiLine" 
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" 
                    onclick="btnConfirm_Click" CssClass="button" Width="102px" 
                     />
                &nbsp;<asp:Button ID="btnCancleShop" runat="server" Text="Cancle Shopping" 
                    onclick="btnCancleShop_Click" CssClass="button" Width="118px" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

