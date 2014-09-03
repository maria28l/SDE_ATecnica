<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="rptDepartamento.aspx.cs" Inherits="catalogos_rptDepartamento" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <CR:CrystalReportViewer ID="crViewer" runat="server" 
        GroupTreeImagesFolderUrl="" Height="50px" 
        ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="200px" 
        Width="350px" />
    
</asp:Content>

