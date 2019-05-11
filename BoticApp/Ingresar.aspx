<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="BoticApp.Ingresar" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="icon.ico">

    <title>Movies Colombia S.A</title>

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <script src="bootstrap/js/popper.min.js" type="text/javascript"></script>
      <script src="bootstrap/js/holder.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Custom styles for this template -->
    <link href="bootstrap/css/signin.css" rel="stylesheet">
  </head>

  <body class="text-center">
    <form class="form-signin" action="index.html">
      <img class="mb-4" src="img/logoapp.svg" alt="" width="72" height="72">
      <h1 class="h3 mb-3 font-weight-normal">Iniciar Sesion</h1>
      <label for="inputEmail" class="sr-only">Usuario</label>
      <input type="text" id="inputEmail" class="form-control" placeholder="Usuario" required autofocus>
      <label for="inputPassword" class="sr-only">Contraseña</label>
        
      <input type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required>
      <a href="index.html"><button class="btn btn-lg btn-primary btn-block ingresar" type="submit">Ingresar</button></a>
      <div class="separator-10"></div>
      <div class="row justify-content-end">
        <a href="#" class="pr-3 text-white">Registrarse</a>
      </div>
      <p class="mt-5 mb-3 text-white">&copy; BoticApp <sup>®</sup></p>
        <div class="alert alert-dark" role="alert">
          <asp:Label ID="lblMensajes" runat="server"></asp:Label>
        </div>
    </form>
  </body>
</html>