<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.ReportePlanes" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager> 
    <div class="reporte">
        <rsweb:ReportViewer ID="rvwrPlanes" runat="server" Height="400px" Width="1000px"></rsweb:ReportViewer>
    </div>

</asp:Content>
