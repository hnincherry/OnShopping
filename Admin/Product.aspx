<%@ Page Title="Adminstration" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Admin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style.css" rel="stylesheet" />
    <style type="text">
        .auto-style1 {
            height: 30px;
            width: 800px;
        }
        .auto-style2 {
            height: 240px;
            width: 800px;
        }
        .auto-style3 {
            width: 800px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="text-align:center;width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblError1" runat="server" Text="[lblError1]" Font="10" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnNew" runat="server" Text="New" cssClass="button" OnClick="btnNew_Click"/>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" cssClass="button" OnClick="btnUpdate_Click"/>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" cssClass="button" OnClick="btnDelete_Click"/>&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Search Type:"></asp:Label>&nbsp;
                        <asp:DropDownList ID="ddlSearchType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchType_SelectedIndexChanged">
                            <asp:ListItem>ProductName</asp:ListItem>
                            <asp:ListItem>CategoryName</asp:ListItem>
                            <asp:ListItem>Price</asp:ListItem>
                            <asp:ListItem>Quantity</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" AutoComplete="Off" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtLoad" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" cssClass="button" OnClick="btnPrint_Click"/>                     
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            CellPadding="5" CellSpacing="1" DataKeyNames="ProID" Width="900px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="No" HeaderText="No" />
                                <asp:BoundField DataField="ProID" HeaderText="ProID" />
                                <asp:BoundField DataField="ProName" HeaderText="Product Name" />
                                <asp:BoundField DataField="CatID" HeaderText="CatID" />
                                <asp:BoundField DataField="CatName" HeaderText="Category Name" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="imgProduct" runat="server" Height="50" ImageUrl='<%#Bind ("Image") %>' Width="50" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div style="text-align:center">
                <asp:Label ID="lblError2" runat="server" Text="[lblError2]" Font-Bold="true" ForeColor="Red" Font-Size="10"></asp:Label>
                <asp:TextBox ID="txtProductID" runat="server" Visible="false"></asp:TextBox>
            </div>
            
            <table style="width:100%;text-align:center;color: #000000;border: 1px solid #000000">
                <tr class="tablehead">
                    <td colspan="2">Product</td>                  
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label2" runat="server" Text="Product Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label3" runat="server" Text="Category Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoryName" runat="server" Width="200"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label4" runat="server" Text="Price:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label5" runat="server" Text="Quantity:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label6" runat="server" Text="Image:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtImage" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
                        <asp:FileUpload ID="FileUploadImage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click"/>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

