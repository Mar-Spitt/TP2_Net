<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home1" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">  
        <div CssClass="menu">
            <!-- <asp:Menu runat="server" ID="menu" DataSourceID="SiteMapDataSource" StaticSubMenuIndent="16px"> </asp:Menu>
            <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server"/>-->
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>
                    <asp:TreeNode Text="1 - Altas, Bajas, Modificaciones y Consultas" Value="abm">
                        <asp:TreeNode  Text="1.1 - Usuarios" Value="nodoUsuarios"></asp:TreeNode>
                        <asp:TreeNode  Text="1.2 - Alumnos" Value="nodoAlumnos"></asp:TreeNode>
                        <asp:TreeNode  Text="1.3 - Especialidades" Value="nodoEspecialidades"></asp:TreeNode>
                        <asp:TreeNode  Text="1.4 - Profesores" Value="nodoProfesores"></asp:TreeNode>
                        <asp:TreeNode  Text="1.5 - Planes" Value="nodoPlanes"></asp:TreeNode>
                        <asp:TreeNode  Text="1.6 - Comisiones" Value="nodoComisiones"></asp:TreeNode>
                        <asp:TreeNode  Text="1.7 - Cursos" Value="nodoCursos"></asp:TreeNode>
                        <asp:TreeNode  Text="1.8 - Materias" Value="nodoMaterias"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2 - Inscripciones de Alumnos a Cursos" Value="nodoInscripciones"></asp:TreeNode>
                    <asp:TreeNode Text="3 - Registro de Notas" Value="nodoNotas"></asp:TreeNode>
                    <asp:TreeNode Text="4 - Reportes" Value="nodoReportes">
                        <asp:TreeNode  Text="4.1 - Cursos" Value="nodoRCursos"></asp:TreeNode>
                        <asp:TreeNode  Text="4.2 - Planes" Value="nodoRPlanes"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </asp:Content>