using Capa.Logica;
using Entidades;
using Entidades.clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace WebFerreteria
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCategorias();
                MostrarProductos();
            }
            try
            {
                if (Session["usuario"] != null)
                {
                    UsuarioLogica logica = new UsuarioLogica();
                    Usuario Usuario = logica.SeleccionarPorID(Session["usuario"].ToString());
                    lblUsuario3.Text = Usuario.Nombre + "  <i class=\"fa fa-user-circle\"></i>";
                    if (Usuario.Rol == Rol.Administrador)
                    {
                        lblAdministrador3.Text = "<a href=\"Direc\\Administrador.aspx\" style=\"text-decoration:none;margin-top:8px;\">Administrador</a>";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void lblUsuario3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {

                }
                else
                {
                    Response.Redirect("Inicio Sesion.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Inicio Sesion.aspx");
            }
        }
        protected void Borrar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Value = "";
            ddlCategoria.SelectedIndex = -1;
            max.Value = "999999";
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            string HtmlCode = "";
            ProductoLogica Logica = new ProductoLogica();
            List<Producto> Productos = Logica.SeleccionarConFiltro(txtBusqueda.Value,Convert.ToInt32(ddlCategoria.SelectedValue),Convert.ToDouble(max.Value));
            foreach(Producto pro in Productos)
            {
                string Imagen = "";
                if(pro.Imagen != null)
                {
                    Imagen = "data:image/jpg;base64," + Convert.ToBase64String(pro.Imagen);
                }
                HtmlCode += ProductoToCard(pro , Imagen);
            }
            lblProductos.Text = HtmlCode;
        }

        private string ProductoToCard(Producto Producto, string Imagen)
        {
            string Img = Imagen != null ? Imagen : "Images/No%20disponible.png";
            string HtmlCode = "";
            HtmlCode = "<div class=\"card mb-1 col-lg-2\" style=\"display: inline-block; margin: 1%; border-radius: 5px;text-align:center\">"+
                            "<div class=\"card-body\">"+
                                "<h5 class=\"card-title\">"+ Producto.Nombre +"</h5>"+
                                "<img src=\""+Img+"\" width=\"200px\" height=\"200px\" runat=\"server\" id=\""+ Producto.IdProducto +"\"></img>" +
                                "<h3>$"+ Producto.Precio +",00</h3>"+
                                "<Button runat=\"server\" class=\"btn btn-outline-success\"/>Añadir</Button>" +
                            "</div>"+
                        "</div>";
            return HtmlCode;
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return System.Drawing.Image.FromStream(ms);
        }

        private void LlenarCategorias()
        {
            CategoriaLogica logica = new CategoriaLogica();
            List<Categoria> Categorias = logica.SeleccionarTodos();
            Categorias.Insert(0, new Categoria() { Nombre = "Todas las Categorías", IdCategoria = -1 });
            ddlCategoria.DataSource = Categorias;
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
        }

        protected void Filtrar_Click(object sender, EventArgs e)
        {
            MostrarProductos();
        }
    }
}