<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantCategorias.aspx.cs" Inherits="WebFerreteria.MantCategorias" %>


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
    <form id="form1" runat="server">
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
                        <a class="nav-link" href="MantCategorias.aspx">Mantenimiento Categoria</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="lblAdministrador" CssClass="nav-link" runat="server" Style="display:none"></asp:LinkButton>
                    </li>
                </ul>
                </div>
            </nav>


       <div class="row">
           <div class="col-lg-8">
             

        <div style=" margin-left:100px" width: 200px ; height: 200px;>
            <div>
            <asp:FileUpload ID="fileUpload" runat="server" />

            <div style="height:300px;width:300px;background-color:green;">
            <asp:Image ID="imagen" runat="server" style="width:300px"/>

        </div>

        Nombre: <asp:TextBox ID="txtnombre" runat="server"></asp:TextBox>
                <br />

        <asp:Button ID="btnSubirImagen" runat="server" Text="Subir Imagen" OnClick="btnSubirImagen_Click" Width="296px" />

        <br />
        <br />
        <br />
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
    <script src="js/parallax.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
