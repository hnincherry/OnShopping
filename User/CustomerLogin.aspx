<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="CustomerLogin.aspx.cs" Inherits="User_CustomerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center">
        <asp:Label ID="lblError" runat="server" Text="[lblError]" Font-Bold="true" ForeColor="Red" Font-Size="10"></asp:Label>
    </div>
    <table style="width: 100%; text-align: center; color: #000000; border: 1px solid #000000">
        <tr class="tablehead">
            <td colspan="2">Login</td>
        </tr>
        <tr>
            <td class="col">
                <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="200" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="button" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

