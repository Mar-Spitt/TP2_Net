<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <table class="login" align="center">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="False" Font-Names="Britannic Bold" Font-Size="Medium" Text="Nombre de Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="180px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="nombreUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El nombre de usuario no puede ser vacío" ForeColor="Red"  Text="*" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblContraseña" runat="server" Font-Bold="False" Font-Names="Britannic Bold" Font-Size="Medium" Text="Contraseña:"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server" Width="180px" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="contraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="La clave no puede ser vacía" ForeColor="Red"  Text="*" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                   <asp:LinkButton ID="lnkRecordarClave" runat="server" OnClick="lnkRecordarClave_Click" CausesValidation="false" OnClientClick = "return alert('Ust es un usuario muy olvidadizo ');">Olvidé mi Constraseña
                    </asp:LinkButton>
                </td>
                <td style="text-align: right">
                   <asp:Button ID="btnIngresar" CssClass="button" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
                
            </tr>
            <tr> 
                <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content> 