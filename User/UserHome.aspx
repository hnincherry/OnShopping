<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="User_UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                <asp:Image ID="imgDisplay" runat="server"
                    ImageUrl="~/Images/gallery/Picture1.jpg" />
            </td>
        </tr>
        <tr>
            <td>
                <a href="Product.aspx">
                    <asp:Image ID="Image2" runat="server"
                        ImageUrl="~/Images/ProImage/CPU1.jpg" Width="100" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image4" runat="server"
                        ImageUrl="~/Images/ProImage/Keyboard1.jpg" Width="100" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image5" runat="server"
                        ImageUrl="~/Images/ProImage/LapTop1.jpg" Width="100" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image7" runat="server"
                        ImageUrl="~/Images/ProImage/Memory1.JPG" Width="80" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image6" runat="server"
                        ImageUrl="~/Images/ProImage/Monitor1.jpg" Width="80" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image8" runat="server"
                        ImageUrl="~/Images/ProImage/MotherBoard1.jpg" Width="80" Height="100" /></a>
                <a href="Product.aspx">
                    <asp:Image ID="Image9" runat="server"
                        ImageUrl="~/Images/ProImage/SU1.jpg" Width="80" Height="100" /></a>
            </td>
        </tr>
    </table>
</asp:Content>

