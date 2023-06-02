<%@ Page Title="ABC Computer Sales Center" Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="User_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txtLoad" runat="server" Visible="False"></asp:TextBox>
<div>
    <div class="box">
    <div class="listbox">
        <div class="CatTitle">Cartegory Name</div>
        <asp:DataList ID="CatNameList" runat="server" DataKeyField="CatID" 
            onselectedindexchanged="CatNameList_SelectedIndexChanged">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/favs.png"/>
                <asp:LinkButton ID="btnCategoryName"  CommandName="Select" runat="server" Text='<%# Eval("CatName") %>' class="list" />
            </ItemTemplate>
        </asp:DataList>
     </div>
        <div class="listbox">
        <div class="CatTitle">View Your Cart</div>
        <div class="img">
            <a href="ShoppingCard.aspx"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/shop_cart.png" Width="50px" Height="50px"/></a>
        </div>
        </div>
    </div>
    <div>
        <asp:DataList ID="Productlist" runat="server" DataKeyField="ProID" 
            RepeatColumns="4" RepeatDirection="Horizontal" BorderColor="#003300" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="3" 
            Width="800px" onselectedindexchanged="Productlist_SelectedIndexChanged">
        <ItemTemplate>
        <div class="prolist">
            <table cellpadding="5" cellspacing="3" align="center">
                <tr>
                    <td>
                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Image") %>' Width="100px" Height="100px"/>
                    </td>
                </tr>
                <tr>
                    <td class="price">
                        Price:<asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="detail">
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">Detail</asp:LinkButton>
                    </d>
                </tr>
            </table>
            </div> 
        </ItemTemplate>
        </asp:DataList>
    </div>
</div> 
</asp:Content>

