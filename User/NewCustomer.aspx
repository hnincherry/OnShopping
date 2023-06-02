<%@ Page Title="ABC Computer Sales Center" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="NewCustomer.aspx.cs" Inherits="User_NewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <table style="color: #000000; border: 1px solid #000000">
            <tr>
                <th colspan="3" class="tablehead">Customer Entry</th>
            </tr>
            <tr>
                <td class="col">Customer Name:</td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" Width="200" autocomplete="Off"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">Address:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" autocomplete="Off"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">Phone</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Width="200px" autocomplete="Off"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" autocomplete="Off"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">ConfirmPassword:</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">CardType:</td>
                <td>
                    <asp:DropDownList ID="ddlCType" runat="server" Width="200px">
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="col">Account No:</td>
                <td>
                    <asp:TextBox ID="txtANo" runat="server" Width="200px" autoComplete="off"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                        CssClass="button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

