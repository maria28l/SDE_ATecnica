<%@ Page Title="" Language="C#" MasterPageFile="~/app/Site.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="catalogos_Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="gvEmpleados" runat="server" CssClass="table table-bordered">
    </asp:GridView>
</asp:Content>

