
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio Sesion.aspx.cs" Inherits="WebFerreteria.Inicio_Sesion1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="=device-width, initial-scale=1, shrink-to-fit=no" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous"/>
    <link href="css/estiloGeneral.css" rel="stylesheet" />
    <link href="css/LogIn.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-light sticky-top">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggler" aria-controls="navbarToggler" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <a class="navbar-brand" href="default.aspx">
            <img src="Images/logo.png" style="width: 50px; height: 50px;" />
            Ferretería JyR
        </a>
        <div class="collapse navbar-collapse" id="navbarToggler">

            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                <li class="nav-item active">
                    <a class="nav-link" href="default.aspx">Inicio<span class="sr-only">(current)</span></a>
                </li>
            </ul>
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta"> 
                <li class="nav-item">
                     <asp:LinkButton CssClass="nav-link" id="active"  runat="server" OnClick="Unnamed_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
    <section id="Content">
        <div class="form-register">
            <h1>Cuenta JYR</h1>
            <h2 class="form-tittle">Iniciar Sesión</h2>
            <div class="contenedor-inputs">
                <asp:TextBox type="email" placeholder="Correo Electrónico" CssClass="input-100" required="required" ID="txtCorreo" runat="server"/>
                <asp:TextBox type="password" placeholder="Constraseña" CssClass="input-100" required="required" ID="txtContraseña" runat="server"/>
                <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesión" class="btn-registrar" type="submit" OnClick="btnIniciar_click"/>
                <asp:Label ID="lblError" CssClass="color:red" runat="server" Text=" "></asp:Label>
                <p class="form-link">¿No tienes una Cuenta?<a href="Direc/Registro.aspx">Registrate aquí</a></p>
            </div>
        </div>
    </section>
    <footer>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-xs-12">
                        <img src="Images/logo.png" style="width: 200px; height: 200px; float: left;" />
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <h3>Menu</h3>
                        <ul class="menu">
                            <li><i class="fa fa-home" aria-hidden="true"></i><a href="Default.aspx">Inicio</a></li>
                            <li><i class="fa fa-users" aria-hidden="true"></i><a href="Nosotros.aspx">Nosotros</a></li>
                            <li><i class="fa fa-box-open" aria-hidden="true"></i><a href="Productos.aspx">Productos</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <h3>Contacto</h3>
                        <ul class="address">
                            <li><i class="fa fa-phone" aria-hidden="true"></i><a href="Contacto.aspx">Teléfonos</a></li>
                            <li><i class="fa fa-map-marker" aria-hidden="true"></i><a href="Contacto.aspx">Dirección</a></li>
                            <li><i class="fa fa-envelope" aria-hidden="true"></i><a href="Contacto.aspx">Correo Electrónico</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        <div id="Copyright">
            <h4>@2018 , All rights reserved</h4>
        </div>
    </footer>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>

