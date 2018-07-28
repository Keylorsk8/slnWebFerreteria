<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WebFerreteria.Direc.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ferretería JyR</title>
    <meta name="viewport" content="=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="../css/estiloGeneral.css" rel="stylesheet" />
    <link href="../css/administrador.css" rel="stylesheet" />
    <script type="text/javascript">
        window.onpageshow = function () {
            var pagina = document.getElementById('lbl').textContent;
            showPanel(pagina);
        }
    </script>
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
                   <asp:LinkButton ID="lblUsuario7" CssClass="nav-link" runat="server" style="height: 24px" OnClick="lblUsuario7_Click">Cuenta</asp:LinkButton>
                </li>
                <li class="nav-item">
                     <asp:Label ID="lblAdministrador2" CssClass="nav-link"  runat="server"></asp:Label>
                </li>
            </ul>
            <div class="form-inline my-2 my-lg-0" runat="server">
                <input class="form-control mr-sm-2" type="search" placeholder="Producto..." aria-label="Search" />
                <button class="btn btn-outline-light my-2 my-sm-0" type="submit"><i class="fa fa-search"></i></button>
            </div>
        </div>
    </nav>
    <asp:Label ID="lbl" CssClass="page" runat="server">0</asp:Label>
    <section id="Content">
        <h1 class="title">Menu Administrador</h1>
        <div class="tabsContainer">
            <div class="btnContainer col-lg-12">
                <a onclick="showPanel(0)">Clientes</a>
                <a onclick="showPanel(1)">Productos</a>
                <a onclick="showPanel(2)">Categorías</a>
                <a onclick="showPanel(3)">?</a>
            </div>
            <div class="tabPanel table-responsive">
                <asp:GridView runat="server" ID="gridClientes" CssClass="table" DataKeyNames="Id" CellPadding="4" GridLines="Horizontal" 
                    AllowPaging="True" PageSize="5" OnRowEditing="gridClientes_RowEditing" OnRowUpdating="gridClientes_RowUpdating" 
                    OnRowCancelingEdit="gridClientes_RowCancelingEdit" OnRowDeleting="gridClientes_RowDeleting" 
                    OnRowDataBound="gridClientes_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" >
                    <Columns>
                        <asp:CommandField ShowEditButton="True"/>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </div>
            <div class="tabPanel">Panel 2</div>
            <div class="tabPanel">
                 <div id="AgregarCategoria">
                     <div class="titulo">
                         <h3>Agregar una Categoría</h3>
                     </div>
                     <div class="InputCategoria1">
                         <h4>Nombre</h4>
                         <asp:TextBox ID="txtNombre"  CssClass="form-text form-control" runat="server" required="required"></asp:TextBox>
                     </div>
                     <div class="InputCategoria2">
                         <h4>Descripción</h4>
                         <asp:TextBox ID="txtDescripcion" CssClass="form-text form-control" runat="server" required="required"></asp:TextBox>
                         <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-success" runat="server" Text="Agregar" OnClick="btnAgregarCategoria_Click"/>
                     </div>
                 </div>
                <div class="table-responsive">
                 <asp:GridView runat="server" ID="gridCategorias" CssClass="table" DataKeyNames="ID" CellPadding="4" GridLines="Horizontal" 
                    AllowPaging="True" PageSize="5" OnRowEditing="gridCategorias_RowEditing" OnRowUpdating="gridCategorias_RowUpdating" 
                    OnRowCancelingEdit="gridCategorias_RowCancelingEdit" OnRowDeleting="gridCategorias_RowDeleting" 
                    OnRowDataBound="gridCategorias_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" >
                    <Columns>
                        <asp:CommandField ShowEditButton="True"/>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                    </div>
            </div>
            <div class="tabPanel">Panel 4</div>
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.0.0.slim.min.js"></script>
    <script src="../js/administrador.js"></script>
</body>
</html>

