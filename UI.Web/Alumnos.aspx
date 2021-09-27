<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.Alumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<table class="margenABM">
		<tr>
			<td align="center" colspan="3">
				<asp:Label ID="Label2" runat="server" Text="ALTAS, BAJAS Y MODIFICACIONES DE USUARIOS" Font-Size="XX-Large"></asp:Label>
				<br/><br/>
			</td>
		</tr>
		<tr>
			<td>
                <asp:Panel ID="formPanel" runat="server" Visible="False">
                        <table border="1">
						    <tr>
							    <td align="center" colspan="2">
							    <asp:Label ID="lblTitulo" runat="server" Text="DATOS"></asp:Label></td>
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
                                <td align="right"><asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label></td>
                                <td><asp:TextBox ID="txtDireccion" runat="server" />
                                    <asp:RequiredFieldValidator ID="direccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La dirección no puede ser vacía" ForeColor="Red"  Text="*"   />
                                </td>
                            </tr>
                            <tr>
							    <td align="right"><asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label></td>
							    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>	
								    <asp:RegularExpressionValidator ID="email" runat="server" ControlToValidate="txtEmail" Text="*" ForeColor="Red" ErrorMessage="Dirección de email invalida!!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
							    </td>
						    </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label></td>
                                <td><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
								    <asp:RequiredFieldValidator ID="telefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El telefono no puede ser vacío" ForeColor="Red"  Text="*" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="dtNacimiento" TextMode="DateTime" runat="server"></asp:TextBox>
                                </td>
                            </tr>
						    <tr>
							    <td align="right"><asp:Label ID="lblLegajo" runat="server" Text="Legajo: " /></td>
							    <td><asp:TextBox ID="txtLegajo" runat="server" ></asp:TextBox>
								    <asp:RequiredFieldValidator ID="legajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="El legajo no puede ser vacío" ForeColor="Red"  Text="*"   />
							    </td>
						    </tr>
						    <tr>
                                <td align="right"><asp:Label ID="lblIdPlan" runat="server" Text="Plan: "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlIdPlan" runat="server" Width="100%"></asp:DropDownList>
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
        </td>
        <td> </td>
        <td valign="top">
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gvAlumnos_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID"/>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion"/>
                        <asp:BoundField DataField="Email" HeaderText="Email"/>
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono"/>
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento"/>
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo"/>
                        <asp:BoundField DataField="IDPlan" HeaderText="IDPlan"/>
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />

                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <asp:LinkButton ID="editarlinkButton" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Agregar</asp:LinkButton>
            </asp:Panel>
        </td>
		</tr>
	    
	</table>
</asp:Content>
