<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteCursos.aspx.cs" Inherits="UI.Web.ReporteCursos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager> 
    <div class="reporte">
        <rsweb:ReportViewer ID="rvwrCursos" runat="server" Height="400px" Width="1000px"></rsweb:ReportViewer>
    </div>
    
</asp:Content>
