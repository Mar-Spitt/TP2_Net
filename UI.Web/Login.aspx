<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
  <meta charset="UTF-8">
  <title>Inicio de sesión</title>
  <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    <link href="Styles/login.css" rel="stylesheet" media="screen" type="text/css"/>
</head>

<body runat="server">

  <div class="login-card">
        <h1>Inicio de sesión</h1><br>

      <form runat="server">
        <asp:TextBox ID="txtUsuario" runat="server" placeholder="Nombre de Usuario" Width="100%" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El nombre de usuario no puede ser vacío" ForeColor="Red"  Text="*" />
    
        <asp:TextBox ID="txtContraseña" SkinID="password" placeholder="Contraseña" TextMode="Password" runat="server" Width="100%" Height="25px"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="contraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="La clave no puede ser vacía" ForeColor="Red"  Text="*" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
    
        <asp:Button ID="btnIngresar" class="login-submit" align="right" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" Height="25px"/>
  
         <div class="login-help" runat="server">
            <asp:LinkButton ID="lnkRecordarClave" runat="server" OnClick="lnkRecordarClave_Click" class="login-help" CausesValidation="false" OnClientClick = "return alert('Ust es un usuario muy olvidadizo ');">Olvidé mi Contraseña</asp:LinkButton>
         </div>
      </form>
</div>

  <script src='http://codepen.io/assets/libs/fullpage/jquery_and_jqueryui.js'></script>

</body>
</html>