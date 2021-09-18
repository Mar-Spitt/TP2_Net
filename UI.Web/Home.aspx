<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Menu runat="server" ID="menu" DataSourceID="SiteMapDataSource"> </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server"/>

</asp:Content>
