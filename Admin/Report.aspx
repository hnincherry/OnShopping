<%@ Page Title="Adminstration" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Admin_Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" ReportSourceID="CrystalReportSource1" AutoDataBind="true" HasRefreshButton="True" ToolPanelView="None"/>
    <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource2" HasRefreshButton="True" ToolPanelView="None" />

    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <REPORT FILENAME="crptAdmin.rpt">
        </REPORT>
    </CR:CrystalReportSource>

    <CR:CrystalReportSource ID="CrystalReportSource2" RUNAT="server">
       <REPORT FILENAME="crptCategory.rpt">
       </REPORT>
    </CR:CrystalReportSource>
</asp:Content>

