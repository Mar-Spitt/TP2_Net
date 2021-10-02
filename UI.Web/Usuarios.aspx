<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div id="container">
		<asp:Label ID="Label1" runat="server" Text="ALTAS, BAJAS Y MODIFICACIONES DE USUARIOS"></asp:Label>
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
					<asp:LinkButton ID="lnkbtnEditar" runat="server" OnClick="lnkbtnEditar_Click" CausesValidation="false">Editar</asp:LinkButton>
					<asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click" CausesValidation="false">Eliminar</asp:LinkButton>
					<asp:LinkButton ID="lnkbtnNuevo" runat="server" OnClick="lnkbtnNuevo_Click" CausesValidation="false">Nuevo</asp:LinkButton>
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
							<td align="right"><asp:Label ID="lblNombre" runat="server" Text="Nombre: "/></td>
							<td><asp:TextBox ID="txtNombre" runat="server"  rows="5"/>
								<asp:RequiredFieldValidator ID="nombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede ser vacío" ForeColor="Red"  Text="*" />
							</td>
						</tr>
						<tr>
							<td align="right"><asp:Label ID="lblApellido" runat="server" Text="Apellido: "/></td>
							<td><asp:TextBox ID="txtApellido" runat="server"/>
								<asp:RequiredFieldValidator ID="apellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido no puede ser vacío" ForeColor="Red"  Text="*" />
							</td>
						</tr>
						<tr>
							<td align="right"><asp:Label ID="lblLegajo" runat="server" Text="Legajo: " /></td>
							<td><asp:TextBox ID="txtLegajo" runat="server" ></asp:TextBox>
								<asp:RequiredFieldValidator ID="legajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="El legajo no puede ser vacío" ForeColor="Red"  Text="*"   />
							</td>
						</tr>
						<tr>
							<td align="right"><asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label></td>
							<td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>	
								<asp:RegularExpressionValidator ID="email" runat="server" ControlToValidate="txtEmail" Text="*" ForeColor="Red" ErrorMessage="Dirección de email invalida!!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
							</td>
						</tr>
                        <tr>
                            <td align="right"><asp:Label ID="lblhabilitado" runat="server" Text="Habilitado: "></asp:Label></td>
                            <td><asp:CheckBox ID="chkHabilitado" runat="server" />
                            </td>
                        </tr>
						<tr>
                            <td align="right"><asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label></td>
                            <td><asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="nombreUsuario" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="El nombre de usuario no puede ser vacío" ForeColor="Red"  Text="*" />
                            </td>
                        </tr>
						<tr>
                            <td align="right"><asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label></td>
                            <td><asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
								<asp:RequiredFieldValidator ID="clave" runat="server" ControlToValidate="txtClave" ErrorMessage="La clave no puede ser vacía" ForeColor="Red"  Text="*" />
                            </td>
                        </tr>
						<tr>
                            <td align="right"><asp:Label ID="lblRepetirClave" runat="server" Text="Confirmar clave: "></asp:Label></td>
                            <td><asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
								
								<asp:CompareValidator ID="repetirClave" runat="server" ControlToValidate="txtRepetirClave" ControlToCompare="txtClave" Operator="Equal" Text="*" ForeColor="Red" ErrorMessage="Las claves ingresadas no coinciden" Type="String" />
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