<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebFerreteria.Direc.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="=device-width, initial-scale=1, shrink-to-fit=no" />
    <script src="../Scripts/jquery-3.3.1.slim.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css"/>
    <link href="../css/estiloGeneral.css" rel="stylesheet" />
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
                    <li class="nav-item">
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
                        <asp:LinkButton ID="lblAdministrador4" CssClass="nav-link" runat="server" Style="display:none"></asp:LinkButton>
                    </li>
                </ul>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0" id="cuenta">
                    <li class="nav-item">
                        <asp:LinkButton ID="lblUsuario5" CssClass="nav-link" runat="server" OnClick="lblUsuario5_Click">Cuenta  <i class="fa fa-user-circle"></i></asp:LinkButton>
                    </li>
                </ul>
                <div class="form-inline my-2 my-lg-0" runat="server">
                   <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" runat="server" id="txtBusqueda" />
                    <button class="btn btn-outline-light my-2 my-sm-0" type="submit" onclick="" runat="server" onserverclick="Buscar_ServerClick" id="Buscar"><i class="fa fa-search"></i></button>
                </div>
            </div>
        </nav>
        <section id="Content">
            <div class="container" style="background-color:white;padding:0px;margin-bottom:2%;">
                <h1 style="color: white;background-color:coral;padding:10px;">Usuarios</h1>
                <div class="container">
                <div class="container">
                    <div class="InputProducto1">
                        <h4>Nombre</h4>
                        <asp:TextBox ID="txtNombreCliente" CssClass="form-text form-control" runat="server" ReadOnly></asp:TextBox>
                    </div>
                    <div class="InputProducto2">
                        <h4>Apellidos</h4>
                        <asp:TextBox ID="txtApellidos" CssClass="form-text form-control" runat="server" ReadOnly></asp:TextBox>
                    </div>
                    <div class="InputProducto3">
                        <h4>Email</h4>
                        <asp:TextBox ID="txtEmail" CssClass="form-text form-control" runat="server" ReadOnly></asp:TextBox>
                    </div>
                    <div class="table-responsive">
                    <h3>Teléfonos</h3>
                    <asp:GridView runat="server" ID="gridTelefonos" CssClass="table" DataKeyNames="ID" CellPadding="4" GridLines="None"
                        AllowPaging="True" PageSize="99999" OnRowDeleting="gridTelefonos_RowDeleting" OnRowDataBound="gridTelefonos_RowDataBound" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57"/>
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"/>
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"/>
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center"/>
                        <RowStyle BackColor="#E3EAEB"/>
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"/>
                        <SortedAscendingCellStyle BackColor="#F8FAFA"/>
                        <SortedAscendingHeaderStyle BackColor="#246B61"/>
                        <SortedDescendingCellStyle BackColor="#D4DFE1"/>
                        <SortedDescendingHeaderStyle BackColor="#15524A"/>
                    </asp:GridView>
                </div>
                </div>
                <asp:GridView runat="server" ID="gridClientes" CssClass="table" DataKeyNames="Id" CellPadding="4" GridLines="None" AutoGenerateSelectButton="true"
                    AllowPaging="True" PageSize="5" OnRowDataBound="gridClientes_RowDataBound" OnSelectedIndexChanged="gridClientes_SelectedIndexChanged" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
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
    <script src="../Scripts/popper.min.js"></script>
    <script src="../js/administrador.js"></script>
</body>
</html>


