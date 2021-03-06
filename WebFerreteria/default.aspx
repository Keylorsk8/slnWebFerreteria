﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFerreteria.Default" %>

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
    <link href="css/estilodefault.css" rel="stylesheet" />
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
                        <a class="nav-link" id="active" href="default.aspx">Inicio<span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Productos.aspx">Productos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Nosotros.aspx">Nosotros</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Contacto.aspx">Contacto</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="lblAdministrador" CssClass="nav-link" runat="server" Style="display:none"></asp:LinkButton>
                    </li>
                </ul>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta">
                    <li class="nav-item">
                        <asp:LinkButton ID="lblUsuario" CssClass="nav-link" runat="server" OnClick="lblUsuario_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                    <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" runat="server" id="txtBusqueda" />
                    <button class="btn btn-outline-light my-2 my-sm-0" type="submit" onclick="" runat="server" onserverclick="Buscar_ServerClick" id="Buscar"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </nav>
        <section id="Content">
            <div id="ImageInicio" class="content-wrap">
                <h1>Ferretería y Materiales JyR</h1>
                <p>La mejor opción para su Construcción</p>
            </div>
            <br />
            <section class="box special features">
                <div class="row" id="titleMain">
                    <h1 id="htitle">Nuestros Servicios</h1>
                </div>
                <div class="row features-row">
                    <div class="col-sm-12 col-lg-6">
                        <span class="icon major accent2"><i class="fa fa-truck"></i></span>
                        <h3>Servicio de Transporte</h3>
                        <p>Contamos con un rápido y seguro servicio de Transporte hasta la puerta de su hogar o proyecto</p>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <span class="icon major accent3"><i class="fa fa-calendar"></i></span>
                        <h3>Excelentes Horarios de Atención</h3>
                        <p>Lunes a Viernes de 7 am a 5 pm y Sábados de 6:30 am a 12 pm</p>
                    </div>
                </div>
                <div class="row features-row">
                    <div class="col-sm-12 col-lg-6">
                        <span class="icon major accent4"><i class="fa fa-phone"></i></span>
                        <h3>Inmediata Asesoría Telefónica</h3>
                        <p>¿Tiene alguna consulta? No dude en llamarnos, su llamada séra asesorada en segundos<a href="Contacto.aspx">Contáctenos</a></p>
                    </div>
                    <div class="col-sm-12 col-lg-6">
                        <span class="icon major accent5"><i class="fa fa-dollar-sign"></i></span>
                        <h3>Precios Competitivos</h3>
                        <p>Tenemos los precios mas bajos, ¿No nos cree? Vealo usted mismo  <a href="Productos.aspx">Ver Productos</a></p>
                    </div>
                </div>
            </section>
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
    <script src="js/parallax.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
