﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebFerreteria._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="width=device-width" />
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" />
    <script src="js/Products.js"></script>
    <link href="css/estiloGeneral.css" rel="stylesheet" />
    <link rel='stylesheet' id='carousel' href='css/carousel.css' type='text/css' media='all' />
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
                        <a class="nav-link" id="active" href="Productos.aspx">Productos</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Nosotros.aspx">Nosotros</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Contacto.aspx">Contacto</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="lblAdministrador3" CssClass="nav-link" runat="server" Style="display: none"></asp:LinkButton>
                    </li>
                </ul>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta">
                    <li class="nav-item">
                        <asp:LinkButton ID="lblUsuario3" CssClass="nav-link" runat="server" OnClick="lblUsuario3_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                   <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" runat="server" id="Search1" />
                    <button class="btn btn-outline-light my-2 my-sm-0" type="submit" onclick="" runat="server" onserverclick="Buscar_ServerClick" id="Buscar"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </nav>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 form-group" style="height: auto; margin-bottom: 0px; background-color: coral; padding-bottom: 20px;">
                    <button class="navbar-toggler btn btn-outline-light my-2 my-sm-0" type="button" data-toggle="collapse" data-target="#Filter" aria-controls="navbarToggler" aria-expanded="false" aria-label="Toggle navigation" style="border: 1px solid white">
                        <i class="fa fa-arrow-down"></i>
                    </button>
                    <h2 class="navbar-brand" style="color: white">Busqueda Avanzada</h2>
                    <div id="Filter" class="collapse navbar-collapse container-fluid" style="background-color: white; height: 99%; border-radius: 5px">
                        <label for="txtBusqueda" class="col-form-label;" style="display: block">Nombre</label>
                        <input runat="server" id="txtBusqueda" class="form-control" placeholder="Producto..." style="display: block" />
                        <label for="ddlCategoria" class="col-form-label" style="display: block">Categoria</label>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" Style="display: block"></asp:DropDownList>
                        <label for="min" style="display: block">Precio Máximo</label>
                        <input type="number" runat="server" id="max" min="1" max="999999" value="999999" class="form-control" style="display: block" />
                        <div class="form-group" style="margin-top: 5px; padding-bottom: 10px;">
                            <asp:LinkButton runat="server" OnClick="Borrar_Click" ID="Borrar" CssClass="btn btn-outline-danger" Text="Borrar" Style="display: inline-block;" />
                            <asp:LinkButton runat="server" OnClick="Filtrar_Click" ID="Filtrar" CssClass="btn btn-outline-success" Text="Buscar" Style="display: inline-block;" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div class="container">
                <div class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <div class="row">
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/01.png" alt="1 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/02.png" alt="2 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/03.png" alt="3 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/04.png" alt="2 slide" /></div>

                            </div>
                        </div>
                        <div class="carousel-item">
                            <div class="row">
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/13.png" alt="4 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/14.png" alt="5 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/15.png" alt="6 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/21.png" alt="3 slide" /></div>
                            </div>
                        </div>
                        <div class="carousel-item">
                            <div class="row">
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/05.png" alt="1 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/06.png" alt="2 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/07.png" alt="3 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/08.png" alt="2 slide" /></div>

                            </div>
                        </div>
                        <div class="carousel-item">
                            <div class="row">
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/11.png" alt="4 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/12.png" alt="5 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/16.png" alt="6 slide" /></div>
                                <div class="col-sm">
                                    <img class="d-block w-55" src="http://distribuidoramora.com.ar/wp-content/themes/grupotodo/images/ferreteria-logos/21.png" alt="3 slide" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-fluid">
                <div style="min-height: 400px; height: auto" runat="server" id="DivProductos">
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

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.carousel');
            var instances = M.Carousel.init(elems, options);
        });
    </script>
</body>
</html>
