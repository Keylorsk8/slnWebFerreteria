<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebFerreteria.Direc.Registro" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="width=device-width" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
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
                <li class="nav-item">
                    <a class="nav-link" href="../Productos.aspx">Productos</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="../Nosotros.aspx">Nosotros</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="../Contacto.aspx">Contacto</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="active" href="../Inicio Sesion.aspx">Cuenta</a>
                </li>
            </ul>
            <div class="form-inline my-2 my-lg-0" runat="server">
                <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" />
                <button class="btn btn-outline-light my-2 my-sm-0" type="submit"><i class="fa fa-search"></i></button>
            </div>
        </div>
    </nav>
    <section id="Content">
        <div class="form-register">
            <h1>Registrarse</h1>
            <h2 class="form-tittle">CREA UNA CUENTA</h2>
            <div class="contenedor-inputs">
                <input type="text" name="nombre" placeholder="Nombre" class="input-50" required/>
                <input type="text" name="apellidos" placeholder="Apellidos" class="input-50" required/>
                <input type="email" name="correo" placeholder="Correo Electrónico" class="input-100" required/>
                <input type="password" name="contraseña" placeholder="Constraseña" class="input-50" required/>
                <input type="password" name="contraseña2" placeholder="Repetir Constraseña" class="input-50" required/>
                <input type="text" name="" placeholder="Teléfono" class="input-100" required/>
                <input type="submit" name="" placeholder="Registrar" class="btn-registrar"/>
                <p class="form-link">¿Ya tienes una Cuenta?<a href="../Inicio Sesion.aspx">Ingresa aquí</a></p>
            </div>
        </div>
    </section>
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-xs-12">
                    <img src="../Images/logo.png" style="width:200px;height:200px;float:left;"/>
                </div>
                <div class="col-md-4 col-xs-12">
                    <h3>Menu</h3>
                    <ul class="menu">
                        <li><a href="#">Inicio</a></li>
                        <li><a href="#">Nosotros</a></li>
                        <li><a href="#">Productos</a></li>
                    </ul>
                </div>
                <div class="col-md-4 col-xs-12">
                    <h3>Contacto</h3>
                    <ul class="address">
                        <li><i class="fa fa-phone" aria-hidden="true"></i><a href="#">Teléfonos</a></li>
                        <li><i class="fa fa-map-marker" aria-hidden="true"></i><a href="#">Dirección</a></li>
                        <li><i class="fa fa-envelope" aria-hidden="true"></i><a href="#">Correo Electrónico</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="Copyright">
            <h4>@2018 , All rights reserved</h4>
        </div>
    </footer>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
</body>
</html>

