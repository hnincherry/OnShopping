<%@ Page Title="ABC Computer Sales Center" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="User_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="color: #000000; border: 1px solid #000000">
    <tr>
        <td colspan="3" class="tablehead">Product Detail</td>
    </tr>
    <tr>
        <td rowspan="3">
            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
        </td>
        <td class="col">Product Name:</td>
        <td>
            <asp:Label ID="lblProductName" runat="server" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="col">Category Name:</td>
        <td>
            <asp:Label ID="lblCategoryName" runat="server" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="col">Price:</td>
        <td>
            <asp:Label ID="lblPrice" runat="server" Width="200px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2">
            <asp:Button ID="btnContinue" runat="server" Text="Continue Shopping" 
                onclick="btnContinue_Click" CssClass="button" Width="130px" />&nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="Add To Card" 
                onclick="btnAdd_Click" CssClass="button" Width="130px" />
        </td>
    </tr>
</table>
</asp:Content>

