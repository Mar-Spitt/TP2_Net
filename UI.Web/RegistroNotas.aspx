<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="container">
        <asp:Label ID="Label1" runat="server" Text="REGISTRO DE NOTAS"></asp:Label>
    </div>
    
    <div id="margen"></div>
	<section id="content">
		<asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="gvRegistroNotas" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gvRegistroNotas_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="NombreApellidoAlu" HeaderText="Alumnos" />
                        <asp:BoundField DataField="DescripcionCurso" HeaderText="Cursos" />
                        <asp:BoundField DataField="DescripcionMateria" HeaderText="Materia" />
                        <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario"/>
                        <asp:BoundField DataField="DescripcionComision" HeaderText="Comisión" />
                        <asp:BoundField DataField="Nota" HeaderText="Notas" />
                        <asp:BoundField DataField="Condicion" HeaderText="Condición" />

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
                <asp:LinkButton ID="lnkCargarNota" runat="server" OnClick="lnkCargarNotaButton_Click">Cargar Nota</asp:LinkButton>
            </asp:Panel>
    </section>
    
    <div CssClass="aside">
        <asp:Panel ID="formPanel" runat="server" Visible="False">
                        <table border="1" align="right">
						    <tr>
							    <td align="center" colspan="2">
							        <strong>
                                    <asp:Label ID="lblTitulo" runat="server" Text="CARGA NUEVA NOTA"></asp:Label>
                                    </strong>
							    </td>
						    </tr>
                            <tr>
                                <td>Número Inscripción</td>
                                <td>
                                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                                </td>
                            </tr>
						    <tr>
							    <td align="right">Alumno</td>
                                <td>
                                    <asp:TextBox ID="txtNombreAlumno" runat="server"></asp:TextBox>
                                </td>
						    </tr>
						    <tr>
							    <td align="right">Curso</td>
                                <td>
                                    <asp:TextBox ID="txtDescripcionCurso" runat="server"></asp:TextBox>
                                </td>
						    </tr>
						    <tr>
							    <td align="right">Comisión</td>
                                <td>
                                    <asp:TextBox ID="txtDescripcionComision" runat="server"></asp:TextBox>
                                </td>
						    </tr>
						    <tr>
							    <td align="right">Materia</td>
                                <td>
                                    <asp:TextBox ID="txtDescripcionMateria" runat="server"></asp:TextBox>
                                </td>
						    </tr>
						    <tr>
							    <td align="right">Año Calendario</td>
                                <td>
                                    <asp:TextBox ID="txtAnioCalendario" runat="server"></asp:TextBox>
                                </td>
						    </tr>
						    <tr>
							    <td align="right">Nota</td>
                                <td>
                                    <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>
                                </td>
						    </tr>
                            <tr>
							    <td align="right">Condición</td>
                                <td>
                                    <asp:TextBox ID="txtCondicion" runat="server"></asp:TextBox>
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
