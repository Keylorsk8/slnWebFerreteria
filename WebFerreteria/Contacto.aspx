<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebFerreteria.Contacto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="=device-width, initial-scale=1, shrink-to-fit=no" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous" />
    <link href="css/estiloGeneral.css" rel="stylesheet" />
    <style>
        .list-group-item.active {
            background-color: coral;
            border-color: transparent;
            padding: 2%;
        }

        .list-group {
            margin: 3%;
        }

        body{
            background-color: seagreen;
        }
    </style>
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
                    <li class="nav-item">
                        <a class="nav-link" href="Productos.aspx">Productos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Nosotros.aspx">Nosotros</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="active" href="Contacto.aspx">Contacto</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="lblAdministrador1" CssClass="nav-link" runat="server" Style="display:none"></asp:LinkButton>
                    </li>
                </ul>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta">
                    <li class="nav-item">
                        <asp:LinkButton ID="lblUsuario1" CssClass="nav-link" runat="server" OnClick="lblUsuario1_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                   <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" runat="server" id="txtBusqueda" />
                    <button class="btn btn-outline-light my-2 my-sm-0" type="submit" onclick="" runat="server" onserverclick="Buscar_ServerClick" id="Buscar"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </nav>
        <div id="Content">
        <div class="container-fluid">
            <div class="list-group">
                <div class="list-group-item list-group-item-action flex-column align-items-start active">
                    <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1">Números Telefónicos</h5>
                    </div>
                </div>
                <div class="list-group-item flex-column align-items-start">
                    <div class="d-flex w-100 justify-content-between">
                        <ul>
                            <li><a>2430-11-31</a></li>
                            <li><a>2430-48-78</a></li>
                            <li><a>7298-70-33</a></li>
                        </ul>
                    </div>
                    <p class="mb-1">Horario : Lunes a Viernes de 7 am a 5 pm y Sábados de 6:30 am a 12 pm</p>
                </div>

            </div>
            <div class="list-group">
                <div class="list-group-item flex-column align-items-start active">
                    <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1">Dirección</h5>
                    </div>
                </div>
                <div class="list-group-item flex-column align-items-start">
                    <div class="d-flex w-100 justify-content-between">
                        <div class="row" style="width:100%">
                            <div class="col-lg-6">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3329.56089566127!2d-84.19726498574846!3d10.039926175101555!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8fa0f7501522726b%3A0xabfd0292074a09df!2sFerreter%C3%ADa+y+Materiales+J+y+R!5e1!3m2!1ses!2scr!4v1533800638347" width="100%" height="100%" frameborder="2" style="border:0" allowfullscreen></iframe>                       
                            </div>
                            <div class="col-lg-6">
                                 <h3>Guadalupe de Alajuela, 25 metros antes de entrada a Calle La Flory.</h3>
                                <img src="Images/Ferreteria.jpg" style="width:100%; border: 2px solid black; height:auto" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="list-group">
                <div class="list-group-item list-group-item-action flex-column align-items-start active">
                    <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1">Correo Electrónico</h5>
                    </div>
                </div>
                <div class="list-group-item flex-column align-items-start">
                    <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1">Nuestro Correo Electrónico es :  <a href="#">Ferreymatjyr@hotmail.com</a></h5>
                    </div>
                        <h3 style="margin-top:2%;color:seagreen;">Contáctanos desde aquí</h3>
            <div id="cont">
                <div class="row">
                    <div class="col-lg-6">
                        <label for="txtnombrec">Nombre</label>
                        <input id="txtnombrec" class="form-control" type="text" runat="server" required/>
                    </div>
                    <div class="col-lg-6">
                        <label for="txtapellidoc">Apellido</label>
                        <input id="txtapellidoc" class="form-control" type="text" size="36" runat="server" required/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <label for="txtcorreoc">E-mail</label>
                        <input id="txtcorreoc" class="form-control" type="text" size="36" runat="server" required/>
                    </div>
                    <div class="col-lg-6">
                        <label for="txttelefonoc">Teléfono</label>
                        <input id="txttelefonoc" class="form-control" type="number" runat="server" required/>
                    </div>
                </div>
                <label for="txtmensajec">Mensaje</label><br />
                <textarea id="txtmensajec" class="form-control" runat="server" required></textarea><br />
                <input id="Reset" runat="server" type="reset" value="Borrar" class="btn btn-danger"/>
                <asp:Button ID="EnviarCorreo" type="button" CssClass="btn btn-success" runat="server" OnClick="EnviarCorreo_Click" Text="Enviar" />
            </div>
                </div>

            </div>
        </div>
        </div>
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
