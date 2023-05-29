<%@ Page Title="Adminstration" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Admin_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../style.css" rel="stylesheet" />
     <style type="text">
        .auto-style1 {
            height: 30px;
            width: 700px;
        }
        .auto-style2 {
            height: 240px;
            width: 700px;
        }
        .auto-style3 {
            width: 700px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="text-align:center;width:100%">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblError1" runat="server" Text="[lblError1]" Font-Bold="true" ForeColor="Red" Font-Size="10pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnNew" runat="server" Text="New" cssClass="button" OnClick="btnNew_Click"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" cssClass="button" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" cssClass="button" OnClick="btnDelete_Click"/>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" cssClass="button" OnClick="btnPrint_Click"/>&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Category Name:"></asp:Label>&nbsp;
                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" AutoComplete="Off" OnTextChanged="txtSearch_Changed"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CatID" CellPadding="5" CellSpacing="1" Width="700px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="No" HeaderText="No"></asp:BoundField>
                                <asp:BoundField DataField="CatID" HeaderText="CatID" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="CatName" HeaderText="Category Name"></asp:BoundField>
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
                <asp:TextBox ID="txtCatID" runat="server" Visible="false"></asp:TextBox>
            </div>
            
            <table style="width:100%;text-align:center;color: #000000;border: 1px solid #000000">
                <tr class="tablehead">
                    <td colspan="2">Category Entry</td>                  
                </tr>
                <tr>
                    <td class="col">
                        <asp:Label ID="Label2" runat="server" Text="Category Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" runat="server" Width="200" AutoComplete="Off"></asp:TextBox>
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

