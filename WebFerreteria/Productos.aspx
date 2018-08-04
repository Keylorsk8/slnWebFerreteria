﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebFerreteria._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="width=device-width" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous" />
    <link href="css/estiloGeneral.css" rel="stylesheet" />
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
                        <asp:LinkButton ID="lblAdministrador3" CssClass="nav-link" runat="server"></asp:LinkButton>
                    </li>
                </ul>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta">
                    <li class="nav-item">
                        <asp:LinkButton ID="lblUsuario3" CssClass="nav-link" runat="server" OnClick="lblUsuario3_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                    <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" />
                    <button class="btn btn-outline-light my-2 my-sm-0" type="submit"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </nav>
        <section id="Content">
            <p>
                La loba Capitolina amamantando a Rómulo y Remo.
                La monarquía romana (en latín, Regnum Romanum) fue la primera forma política de gobierno de la ciudad Estado de Roma. Abarcó desde el momento legendario de su fundación, el 21 de abril del 753 a. C., hasta su final en el 509 a. C. con la expulsión del último rey, Tarquinio el Soberbio. Su caída marcó el comienzo de la República romana.

                Los orígenes de la monarquía son imprecisos, si bien parece claro que fue la primera forma de gobierno de la ciudad, un dato que parecen confirmar la arqueología y la lingüística. La mitología romana vincula el origen de Roma y de la institución monárquica al héroe troyano Eneas, quien huyendo de la destrucción de su ciudad, navegó hacia el Mediterráneo occidental hasta llegar a Italia. Allí fundó la ciudad de Lavinio. Posteriormente, su hijo Ascanio fundó Alba Longa, de cuya familia real descendieron los gemelos Rómulo y Remo, los fundadores de Roma.

                Leer más...
                Anteriores: Luis I de Hungría, Máximo térmico del Paleoceno-Eoceno, Vulcanismo en Ío.
                Artículo bueno Artículo bueno
                5jo1.gif
                La Carta de juramento (五箇条の御誓文 Gokajō no Goseimon?, literalmente, el Juramento en cinco artículos) fue promulgada en la entronización de Meiji Tennō como emperador de Japón el 7 de abril de 1868. El juramento delineaba las principales metas y el curso de acción del reinado de Meiji Tennō, preparando el marco legal para la modernización del Japón, buscando dejar atrás el período del bakumatsu y el Shogunato Tokugawa, pero tratando de incluir a su vez a aquellos territorios que apoyaban al régimen anterior. Continuó influyendo durante la era Meiji y principios del siglo xx, y se la puede considerar como la primera constitución del Japón moderno.
                Leer más...
                Anteriores: Pigmento, Dioscoreales, Anexo:Aeronaves y armamento del Ejército del Aire de España.
                Recurso del día Recurso del día
                Puente de madera
                Puente de madera que une el barrio de Punta del Caimán con la Playa de la Gaviota, en Isla Cristina, Huelva.
                Archivo
                Portales
                Artes
                Artes: Arquitectura – Cine – Danza – Literatura – Música – Música clásica – Pintura – Teatro

                Ciencias sociales
                Ciencias sociales: Comunicación – Derecho – Economía – Filosofía – Lingüística – Psicología – Sociología

                Ciencias naturales
                Ciencias naturales: Astronomía – Biología – Botánica – Física – Medicina – Matemática – Química

                Geografía
                Geografía: África – América – Antártida – Asia – Europa – Oceanía – Países

                Historia
                Historia: Prehistoria – Edad Antigua – Edad Media – Edad Moderna – Edad Contemporánea

                Política
                Política: Feminismo – LGBT – Marxismo – Nacionalismo – Socialismo – Terrorismo

                Religión
                Religión: Ateísmo – Budismo – Cristianismo – Iglesia católica – Islam – Judaísmo – Mitología

                Tecnologías
                Tecnologías: Biotecnología – Exploración espacial – Informática – Ingeniería – Software libre
            </p>
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
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
