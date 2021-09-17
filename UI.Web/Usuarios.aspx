<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
		<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
			SelectedRowStyle-BackColor="Black"
			SelectedRowStyle-ForeColor="White"
			DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
			<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
			<Columns>
				<asp:BoundField HeaderText="Nombre" DataField="Nombre" />
				<asp:BoundField HeaderText="Apellido" DataField="Apellido" />
				<asp:BoundField HeaderText="Email" DataField="Email" />
				<asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
				<asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
				<asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
			</Columns>
			<EditRowStyle BackColor="#999999" />
			<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
			<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
			<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
			<SortedAscendingCellStyle BackColor="#E9E7E2" />
			<SortedAscendingHeaderStyle BackColor="#506C8C" />
			<SortedDescendingCellStyle BackColor="#FFFDF8" />
			<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
		</asp:GridView>
	</asp:Panel>
	<asp:Panel ID="gridActionsPanel" runat="server">
		<asp:LinkButton ID="lnkbtnEditar" runat="server" OnClick="lnkbtnEditar_Click">Editar</asp:LinkButton>
		<asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click">Eliminar</asp:LinkButton>
		<asp:LinkButton ID="lnkbtnNuevo" runat="server" OnClick="lnkbtnNuevo_Click">Nuevo</asp:LinkButton>
	</asp:Panel>
	<asp:Panel ID="formPanel" Visible="false" runat="server">
		<asp:Label ID="lblNombre" runat="server" Text="Nombre: "/>
		<asp:TextBox ID="txtNombre" runat="server"/>
		<br />
		<asp:Label ID="lblApellido" runat="server" Text="Apellido: "/>
		<asp:TextBox ID="txtApellido" runat="server"/>
		<br />
		<asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
		<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
		<br />
		<asp:Label ID="lblhabilitado" runat="server" Text="Habilitado: "></asp:Label>
		<asp:CheckBox ID="chkHabilitado" runat="server"></asp:CheckBox>
		<br />
		<asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
		<asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
		<br />
		<asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
		<asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
		<br />
		<asp:Label ID="lblRepetirClave" runat="server" Text="Confirmar clave: "></asp:Label>
		<asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
		<br />
	</asp:Panel>
	<asp:Panel ID="formActionsPanel" runat="server">
		<asp:LinkButton ID="lnkbtnAceptar" runat="server" OnClick="lnkbtnAceptar_Click">Aceptar</asp:LinkButton>
		<asp:LinkButton ID="lnkbtnCancelar" runat="server">Cancelar</asp:LinkButton>
	</asp:Panel>
</asp:Content>
