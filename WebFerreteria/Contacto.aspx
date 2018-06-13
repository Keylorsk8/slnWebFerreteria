<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebFerreteria._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Ferretería JyR</title>
        <meta name="viewport" content="width=device-width"/>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
        <link rel='stylesheet prefetch' href='https://netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.css'/>
        <link href="css/estiloHeader.css" rel="stylesheet"/>
        <link href="css/estilofooter.css" rel="stylesheet" />
    </head>
    <body>
        <form id="form3" runat="server">
        <header class="navbar nBar navbar-fixed-top" role="navigation">
            <nav class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <div class="small-logo-container">
                        <a class="small-logo" href="../default.aspx">Ferretería JyR</a>
                    </div>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="default.aspx">Inicio</a></li>
                        <li><a href="Productos.aspx">Productos</a></li>
                        <li><a href="#">Nosotros</a></li>
                        <li class="active"><a href="Contacto.aspx">Contacto</a></li>
                        <li><a href="Inicio Sesion.aspx">Cuenta</a></li>
                    </ul>
                </div>
            </nav>
        </header>
        <section id="Content">
            
        </section>
        <div class="search-text"> 
            <div class="container">
                <div class="row text-center">
                    <div class="form">
                        <h4>Suscribirse para recibir nuestrar nuevas promociones</h4>
                        <form id="search-form" class="form-search form-horizontal">
                            <input type="text" class="input-search" placeholder="Correo Electrónico"/>
                            <button type="submit" class="btn-search">Suscribirse</button>
                        </form>
                    </div> 
                </div>         
            </div>     
	    </div>
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <span class="logo">Ferretería y Materiales JyR</span>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <h3>Menu</h3>
                        <ul class="menu">        
                          <li><a href="#">Inicio</a></li>
                          <li><a href="#">Nosotros</a></li>
                          <li><a href="#">Productos</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <h3>Contacto</h3>
                        <ul class="address">       
                            <li><i class="fa fa-phone" aria-hidden="true"></i> <a href="#">Teléfonos</a></li>
                            <li><i class="fa fa-map-marker" aria-hidden="true"></i> <a href="#">Dirección</a></li> 
                            <li><i class="fa fa-envelope" aria-hidden="true"></i> <a href="#">Correo Electrónico</a></li> 
                        </ul>
                    </div>
                </div>
            </div>
            <div id="Copyright">
                <h4>@2018 , All rights reserved</h4>
            </div>
        </footer>
        </form>
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src='http://netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js'></script> 
    </body>
</html>
