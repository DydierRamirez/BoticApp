<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BoticApp.default" %>

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
        <img class="mb-4" src="img/logoapp.svg" alt="" width="72" height="72">
        <asp:Panel ID="pnlInicioSesion" runat="server">
            <h1 class="h3 mb-3 font-weight-normal">Iniciar Sesion</h1>
            <label for="inputEmail" class="sr-only">Usuario</label>
            <%--<input type="text" id="inputEmail" class="form-control" placeholder="Usuario" required autofocus>--%>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" required autofocus></asp:TextBox>
            <label for="inputPassword" class="sr-only">Contraseña</label>
            <%--<input type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required>--%>
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            <%--<a href="index.html"><button class="btn btn-lg btn-primary btn-block ingresar" type="submit">Ingresar</button></a>--%>
            <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-lg btn-primary btn-block ingresar" Text="Ingresar" />
        </asp:Panel>
        <asp:Panel ID="pnlRestablecer" runat="server" Visible="false">
            <h1 class="h3 mb-3 font-weight-normal">Restablecer</h1>
            <label for="inputEmail" class="sr-only">Correo</label>
            <%--<input type="text" id="inputEmail" class="form-control" placeholder="Usuario" required autofocus>--%>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required autofocus></asp:TextBox>
            <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-lg btn-primary btn-block ingresar" Text="Enviar" />
        </asp:Panel>
        <div class="separator-10"></div>
        <asp:LinkButton ID="lknNuevo" runat="server" CssClass=" text-white badge badge-dark badge-primary text-wrap">Registrar</asp:LinkButton>
        <asp:Panel ID="pnlNuevo" runat="server" CssClass="mx-auto" Visible="false">
            <div class="pl-3 row justify-content">
            <%--<a href="#" class="pr-3 text-white">Registrarse</a>--%>
            <asp:LinkButton ID="lknRegistrar" runat="server" CssClass="text-white badge badge-dark badge-primary text-wrap">Nuevo usuario</asp:LinkButton>
            <div class="separator-10"></div>
            <asp:LinkButton ID="lknRegistrarFarmaia" runat="server" CssClass="text-white badge badge-dark badge-primary text-wrap">Nueva Farmacia</asp:LinkButton>
        </div>
        </asp:Panel>
        <div class="row justify-content-end">
            <asp:LinkButton ID="lknRestablecer" runat="server" CssClass="text-white badge badge-dark badge-primary text-wrap">Restablecer</asp:LinkButton>
            <%--<a href="#" class="pr-3 text-white">Restaurar</a>--%>
        </div>
        <p class="mt-5 mb-3 text-white">&copy; BoticApp <sup>®</sup></p>

    </form>
</body>
</html>
