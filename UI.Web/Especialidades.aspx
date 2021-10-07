<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div id="container">
		<asp:Label ID="Label1" runat="server" Text="ALTAS, BAJAS Y MODIFICACIONES DE ESPECIALIDADES"></asp:Label>
	</div>

	<div id="margen"></div>
	<section id="content">
		<asp:Panel ID="gridPanel" runat="server" Width="100%">
					<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
						SelectedRowStyle-BackColor="Black"
						SelectedRowStyle-ForeColor="White"
						DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
						<Columns>
							<asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
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
					<asp:LinkButton ID="lnkbtnEditar"  runat="server" OnClick="lnkbtnEditar_Click" CausesValidation="false">Editar</asp:LinkButton>
					<asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click" CausesValidation="false">Eliminar</asp:LinkButton>
					<asp:LinkButton ID="lnkbtnNuevo"  runat="server" OnClick="lnkbtnNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
				</asp:Panel>
	</section>

	<div CssClass="aside">
		<asp:Panel ID="formPanel" Visible="false" runat="server">
					<table id="table" border="1">
						<tr>
							<td align="center" colspan="2">
							    <strong>
                                <asp:Label ID="lblTitulo" runat="server" Text="DATOS"></asp:Label>
                                </strong></td>
						</tr>
						<tr>
							<td align="right"><asp:Label ID="lblDescripcion" runat="server" Text="Descripción: "/></td>
							<td><asp:TextBox ID="txtDescripcion" runat="server"  rows="5"/>
								<asp:RequiredFieldValidator ID="descripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="La descripcion no puede ser vacío" ForeColor="Red"  Text="*" />
							</td>
						</tr>
						<tr>
							<td align="right" colspan="2">
								<asp:Panel ID="formActionsPanel" runat="server">
									<asp:LinkButton ID="lnkbtnCancelar" runat="server" OnClick="lnkbtnCancelar_Click" CausesValidation="false">Cancelar </asp:LinkButton>
									<asp:LinkButton ID="lnkbtnAceptar" runat="server" OnClick="lnkbtnAceptar_Click" OnClientClick = "return confirm('¿Desea guardar los cambios ?');"> Aceptar</asp:LinkButton>
									<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
								</asp:Panel>
							</td>
						</tr>
					</table>
				</asp:Panel>
	</div>
</asp:Content>
