<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restaurar.aspx.cs" Inherits="BoticApp.Restaurar" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="icon.ico">

    <title>BoticApp</title>

    <!-- Bootstrap core CSS -->
    <link href="Recursos/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <script src="Recursos/bootstrap/js/popper.min.js" type="text/javascript"></script>
      <script src="Recursos/bootstrap/js/holder.min.js" type="text/javascript"></script>
    <script src="Recursos/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Custom styles for this template -->
    <link href="Recursos/bootstrap/css/signin.css" rel="stylesheet">
  </head>

  <body class="text-center">
    <form class="form-signin" runat="server">
        <asp:HiddenField ID="hdID_USUARIO"  runat="server"/>
      <img class="mb-4" src="img/logoapp.svg" alt="" width="72" height="72">
      <h1 class="h3 mb-3 font-weight-normal">Restablecer</h1>
      <label for="inputPassword" class="sr-only">Contraseña</label>
      <%--<input type="text" id="inputEmail" class="form-control" placeholder="Usuario" required autofocus>--%>
        <asp:TextBox id="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
      <label for="inputPassword" class="sr-only">Confirmar Contraseña</label>
      <%--<input type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required>--%>
        <asp:TextBox id="txtConfirmarContrasena" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
      <%--<a href="index.html"><button class="btn btn-lg btn-primary btn-block ingresar" type="submit">Ingresar</button></a>--%>
        <asp:Button id="btnAceptar" runat="server"  CssClass="btn btn-lg btn-primary btn-block ingresar" Text="Aceptar"/>
      <div class="separator-10"></div>
      <div class="row justify-content-end">
        <a href="#" class="pr-3 text-white">Registrarse</a>
      </div>
      <p class="mt-5 mb-3 text-white">&copy; BoticApp <sup>®</sup></p>
        
    </form>
  </body>
</html>