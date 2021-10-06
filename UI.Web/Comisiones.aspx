<%@ Page Title="ABM Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="container">
        <asp:Label ID="Label1" runat="server" Text="ALTAS, BAJAS Y MODIFICACIONES DE COMISIONES"></asp:Label>
    </div>
    
    <div id="margen"></div>
	<section id="content">
		<asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="gvComisiones" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gvComisiones_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                        <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad"/>
                        <asp:BoundField DataField="IDPlan" HeaderText="ID Plan"/>
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
    </section>
    
    <div CssClass="aside">
        <asp:Panel ID="formPanel" runat="server" Visible="False">
                        <table border="1" align="right">
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
							    <td align="right"><asp:Label ID="lblAnioEspecialidad" runat="server" Text="Año Especialidad: "/></td>
							    <td><asp:TextBox ID="txtAnioEspecialidad" runat="server"/>
								    <asp:RequiredFieldValidator ID="anioEspecialidad" runat="server" ControlToValidate="txtAnioEspecialidad" ErrorMessage="El año de especialidad no puede ser vacío" ForeColor="Red"  Text="*" />
							    </td>
						    </tr>
				            <tr>
                                <td align="right"><asp:Label ID="lblIdPlan" runat="server" Text="ID Plan: "></asp:Label></td>
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
    </div>
</asp:Content>
