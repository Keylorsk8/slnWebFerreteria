<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebFerreteria.Direc.Registro" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous"/>
    <link href="../css/estiloGeneral.css" rel="stylesheet" />
    <link href="../css/LogIn.css?" rel="stylesheet" />
</head>
<body>
    <form runat="server">
       <nav class="navbar navbar-expand-lg navbar-dark bg-light sticky-top">
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarToggler" aria-controls="navbarToggler" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <a class="navbar-brand" href="../default.aspx">
            <img src="../Images/logo.png" style="width: 50px; height: 50px;" />
            Ferretería JyR
        </a>
        <div class="collapse navbar-collapse" id="navbarToggler">

            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                <li class="nav-item active">
                    <a class="nav-link" href="../default.aspx">Inicio<span class="sr-only">(current)</span></a>
                </li>
            </ul>
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta"> 
                <li class="nav-item">
                     <asp:LinkButton id="active" CssClass="nav-link" runat="server" OnClick="lblUsuario5_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
    <section id="Content">
        <div class="form-register">
            <h1>Registrarse</h1>
            <h2 class="form-tittle">CREA UNA CUENTA</h2>
            <div class="contenedor-inputs">
                <asp:TextBox ID="txtNombre" runat="server" type="text" name="nombre" placeholder="Nombre" class="input-50" required="required"></asp:TextBox>
                <asp:TextBox ID="txtApellidos" runat="server" type="text" name="apellidos" placeholder="Apellidos" class="input-50" required="required"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" type="email" name="correo" placeholder="Correo Electrónico" class="input-100" required="required"></asp:TextBox>
                <asp:TextBox ID="txtContraseña" runat="server" type="password" name="contraseña" placeholder="Constraseña" class="input-50" required="required"></asp:TextBox>
                <asp:TextBox ID="txtContraseña2" runat="server" type="password" name="contraseña2" placeholder="Repetir Constraseña" class="input-50" required="required"></asp:TextBox>
                <asp:TextBox ID="txtTelefono" runat="server" type="text" name="telefono" placeholder="Teléfono" class="input-100" required="required"></asp:TextBox>
                <asp:Button ID="btnregistrarse" runat="server" Text="Registrarse" class="btn-registrar" type="submit" OnClick="btnregistrarse_Click"/>
                <asp:Label ID="lblError" runat="server" Text=" "></asp:Label>
                <p class="form-link">¿Ya tienes una Cuenta?<a href="../Inicio Sesion.aspx">Ingresa aquí</a></p>
            </div>
        </div>
    </section>
    <footer>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-xs-12">
                        <img src="../Images/logo.png" style="width: 200px; height: 200px; float: left;" />
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <h3>Menu</h3>
                        <ul class="menu">
                            <li><i class="fa fa-home" aria-hidden="true"></i><a href="../Default.aspx">Inicio</a></li>
                            <li><i class="fa fa-users" aria-hidden="true"></i><a href="../Nosotros.aspx">Nosotros</a></li>
                            <li><i class="fa fa-box-open" aria-hidden="true"></i><a href="../Productos.aspx">Productos</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <h3>Contacto</h3>
                        <ul class="address">
                            <li><i class="fa fa-phone" aria-hidden="true"></i><a href="../Contacto.aspx">Teléfonos</a></li>
                            <li><i class="fa fa-map-marker" aria-hidden="true"></i><a href="../Contacto.aspx">Dirección</a></li>
                            <li><i class="fa fa-envelope" aria-hidden="true"></i><a href="../Contacto.aspx">Correo Electrónico</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        <div id="Copyright">
            <h4>@2018 , All rights reserved</h4>
        </div>
    </footer>
    </form>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
</body>
</html>

